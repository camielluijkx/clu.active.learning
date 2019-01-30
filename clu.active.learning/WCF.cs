using SchoolGradesDBModel;
using System;
using System.IO;
using System.Linq;
using System.Net;
using System.Runtime.Serialization;
using System.Text;

namespace clu.active.learning
{
    /*
    
    Windows Communication Foundation (WCF)
    
    The .NET Framework provides the infrastructure to enable you to integrate your applications with 
    remote data sources. The remote data source could be anything from an FTP site to an ASP.NET or 
    WCF Web Service. 

    When consuming a remote data source in your application, the .NET Framework uses requests and 
    responses to pass messages between the two (or more) systems. This involves the following steps: 

        1. Initiate a connection to the remote data source. This might include passing a security 
           token or user credentials so that the remote data source can authenticate you. 
        2. Send a request message to the remote data source. This message may also include any data 
           that the remote data source requires to satisfy the request, such as the identifier for 
           the sales record you want to retrieve. 
        3. Wait for the remote data source to process your request and issue a response. As a 
           developer, you have no control over how long it might take to receive a response from a 
           web service. 
        4. Process the response, and extract any data that is included in the response.

    https://docs.microsoft.com/en-us/dotnet/api/system.net?view=netframework-4.7.2

    Web Connectivity in the .NET Framework 
    
    The .NET Framework provides the System.Net namespace, which contains several request and 
    response classes that enable you to target different data sources. The following table describes 
    some of these request and response classes. 
    
    Class               Description
    WebRequest          An abstract class that provides the base infrastructure for any request to a 
                        Uniform Resource Identifier (URI). 
    WebResponse         An abstract class that provides the base infrastructure to process any 
                        response from a URI. 
    HttpWebRequest      A derivative of the WebRequest class that provides functionality for any HTTP 
                        web request. 
    HttpWebResponse     A derivative of the WebResponse class that provides functionality to process 
                        any HTTP web response. 
    FtpWebRequest       A derivative of the WebRequest class that provides functionality for any FTP 
                        request. 
    FtpWebResponse      A derivative of the WebResponse class that provides functionality to process 
                        any FTP response. 
    FileWebRequest      A derivative of the WebRequest class that provides functionality for requesting 
                        files. 
    FileWebResponse     A derivative of the WebResponse class that provides functionality to process a 
                        file response. 

    Depending on whether you want to send a request to a web service by using HTTP or you want to 
    download a file from an FTP site, the .NET Framework provides the necessary classes for you to 
    consume these remote data sources in your applications. 

    The protocol that your remote data source uses determines the request and response classes you 
    must use. Irrespective of the classes you use, you can apply the same pattern to send a request 
    and receive a response. 

    Defining a Data Contract

    A remote data source can expose any type of data. For example, a web service can expose binary 
    streams, scalar values, or custom objects. The choice of the type of data that you expose is 
    determined by the requirements of your application, but how you expose it is controlled by the 
    data contracts that you define in your web services. 

    If you want to expose a custom object from a web service, you must provide metadata that describes 
    the structure of the object. The serialization process uses this metadata to convert your object 
    into a transportable format, such as XML or JavaScript Object Notation (JSON). This metadata provides 
    instructions to the serializer that enable you to control which types and members are serialized. 

    https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.datacontractattribute?view=netframework-4.7.2

    The .NET Framework provides the System.Runtime.Serialization namespace, which includes the DataContract 
    and DataMember attributes. You can use these attributes to define serializable types and members. 

    */
    public static class WCF
    {
        #region Implementation

        public class SalesDataLoader
        {
            private Uri _serviceUri;
            
            // Declare a global object to encapsulate an HTTP request.
            private HttpWebRequest _request;

            public SalesDataLoader(Uri serviceUri)
            {
                if (serviceUri == null)
                    throw new NullReferenceException("serviceUri");

                this._serviceUri = serviceUri;
            }

            public SalesPerson GetPersonByEmail(string email)
            {
                if (string.IsNullOrEmpty(email))
                    return null;

                this.InitializeRequest();

                var rawData = Encoding.Default.GetBytes(
                    "{\"emailAddress\":\"" + email.Trim() + "\"}");

                // Configure the request to send JSON data.
                this._request.Method = "POST";
                this._request.ContentType = "application/json";
                this._request.ContentLength = rawData.Length;

                this.writeDataToRequestStream(rawData);

                return this.readDataFromResponseStream();
            }

            private void InitializeRequest()
            {
                // Instantiate the _request object.
                this._request = WebRequest.Create(this._serviceUri.AbsoluteUri) as HttpWebRequest;

                if (this._request == null)
                    throw new NullReferenceException("_request");
            }

            private void writeDataToRequestStream(byte[] data)
            {
                // Write data to the request stream.
                var dataStream = this._request.GetRequestStream();
                dataStream.Write(data, 0, data.Length);
                dataStream.Close();
            }

            private SalesPerson readDataFromResponseStream()
            {
                // Create an HttpWebResponse object.
                var response = this._request.GetResponse() as HttpWebResponse;

                // Check to see if the response contains any data.
                if (response.ContentLength == 0)
                    return null;

                // Read and process the response data.
                var stream = new StreamReader(response.GetResponseStream());
                var result = SalesPerson.FromJson(stream.BaseStream);
                stream.Close();

                return result;
            }
        }

        #endregion

        #region Public Methods

        public static void HandlingNetworkExceptions()
        {
            /*
           
            Handling Network Exceptions
            
            When consuming any remote resources, whether an FTP site or an HTTP web service, you cannot
            guarantee that the resource is online and listening for your request. If you try to send a 
            request to a web service by using the HttpWebRequest class and the web service is not online, 
            the GetResponse method call will throw a WebException exception with the following message: 

                WebException – The remote server returned an error: (404) Not Found. 

            Similarly, if you try to access a secure web service with the wrong credentials or security 
            token, the GetResponse method call will throw a WebException exception with the following 
            message: 

                WebException – The remote server returned an error: 401 unauthorized 
            
            If you do not handle these exceptions in your code, they will cause your application to fail, 
            offering a poor user experience. Therefore, as a minimum, you should enclose any logic that 
            communicates with a remote data source in a try/catch statement, with the catch block handling 
            exceptions of type WebException. 

            */
            Console.WriteLine("* Handling Network Exceptions");
            {

            }
        }

        public static void UsingAuthentication()
        {
            /* 
            
            Using AUthentication
            
            Remote data sources are often protected to prevent unauthorized users from using the service 
            and gaining access to data. Exposing an unprotected data source over the web can lead to 
            unauthorized users sending requests and increasing the load on the data source. There are many 
            ways in which you can secure remote data sources. One approach is to authenticate each user who 
            attempts to connect to the remote data source.

            Type of Authentication 

            The following table describes some of the common authentication techniques that you can use to 
            secure remote data sources. 

            Authentication mechanism        Description
            Basic                           Enables users to authenticate by using a user name and password. 
                                            Basic authentication does not encrypt the credentials while in 
                                            transit, which means that unauthorized users may access the 
                                            credentials. 
            Digest                          Enables users to authenticate by using a user name and password, 
                                            but unlike basic authentication, the credentials are encrypted. 
            Windows                         Enables clients to authenticate by using their Windows domain 
                                            credentials. Windows authentication uses either hashing or a 
                                            Kerberos token to securely authenticate users. Windows 
                                            authentication is typically used to provide a single sign-on 
                                            (SSO) experience in organizations. 
            Certificate                     Enables only clients that have the correct certificate installed 
                                            to authenticate with the service. 

            The .NET Framework provides a number of classes that you can use to authenticate with a secure 
            remote data source.

            Authenticating Users by Using Credentials 

            https://docs.microsoft.com/en-us/dotnet/api/system.net.networkcredential?view=netframework-4.7.2

            When communicating with a remote data source that requires a user name and password, you use the 
            Credentials property that is exposed by any class that is derived from the WebRequest base class 
            to pass the credentials to the data source. You can set the Credentials property to any object 
            that implements the ICredentials interface: 

                • The NetworkCredential class implements the ICredentials interface and enables you to 
                  encapsulate a user name and password. The following code example shows how to instantiate 
                  a NetworkCredential object and pass values for the user name and password to the class 
                  constructor. 
                • The CredentialCache class provides a number of members that enable you to get credentials 
                  in the form of an ICredentials object. These members include the DefaultCredentials 
                  property, which returns an ICredentials object containing the credentials that the user 
                  is currently logged on with. The following code example shows how to use the 
                  DefaultCredentials property to get the current user’s credentials. 
            
            Authenticating Users by Using an X509 Certificate 

            You can use an X509 certificate as a security token to authenticate users. Instead of users 
            having to specify credentials when they access the remote data source, they will automatically 
            gain access as long as the request that is sent includes the correct X509 certificate. To the 
            users, this means they need the correct X509 certificate in their certificate store on the 
            computer where the client application is running. 

            When the remote data source receives the request, it must extract and process the X509 
            certificate. If the X509 certificate is invalid, the remote data source can return a suitable 
            response, such as a "The remote server returned an error: 401 unauthorized" message.

            */
            Console.WriteLine("* Using Authentication");
            {
                Console.WriteLine("** Using NetworkCredential");
                {
                    var uri = "http://Sales.FourthCoffee.com/SalesService.svc/GetSalesPerson";
                    var request = WebRequest.Create(uri) as HttpWebRequest;
                    var username = "jespera";
                    var password = "Pa$$w0rd";
                    request.Credentials = new NetworkCredential(username, password);
                }

                Console.WriteLine("** Using CredentialCache");
                {
                    var uri = "http://Sales.FourthCoffee.com/SalesService.svc/GetSalesPerson";
                    var request = WebRequest.Create(uri) as HttpWebRequest;
                    request.Credentials = CredentialCache.DefaultCredentials;
                }

                Console.WriteLine("** Using X509Certificate");
                {
                    var uri = "http://Sales.FourthCoffee.com/SalesService.svc/GetSalesPerson";
                    var request = WebRequest.Create(uri) as HttpWebRequest;
                    //var certificate = FourthCoffeeCertificateServices.GetCertificate();
                    //request.ClientCertificates.Add(certificate);
                }
            }
        }

        public static void UsingWebRequest()
        {
            /*
            
            You use requests and responses to send data to or retrieve data from a remote data source.

            Each derivative of the WebRequest and WebResponse classes enables you to send and receive 
            data by using the specific protocol that the class implements. For example, the 
            HttpWebRequest class enables you to send requests to a web service by using the HTTP 
            protocol. 

            The WebRequest base class includes the following members that you can use to send data to 
            a remote data source: 
                
                • ContentType. This property enables you to set the type of data that the request will 
                  send. For example, if you are sending JSON data by using the HttpWebRequest class, 
                  you use the application/json content type. 
                • Method. This property enables you to set the type of method that the WebRequest object 
                  will use to send the request. For example, if you are uploading a file by using the 
                  FtpWebRequest class, you use the STOR method. 
                • ContentLength. This property enables you to set the number of bytes that the request 
                  will send. 
                • GetRequestStream. This method enables you to access and write data to the underlying 
                  data stream in the request object. 
        
            The WebResponse class provides the GetResponseStream method, which enables you to access and 
            stream data from the response. 

            Sending Data to a Remote Data Source 

            Whether you are sending data to a web service or uploading a file to an FTP site, the process 
            for creating the request remains the same: 

                1. Get the URI to the remote data source and the data you want to send.
                2. Create the request object.
                3. Configure the request object, which includes setting the request method and the length 
                   of the data that the request will send. 
                4. Stream the data to the request object.

            */
            Console.WriteLine("* Using WebRequest");
            {
                Console.WriteLine("** Sending Data to a WebService");
                {
                    // Get the URI and the data.
                    var uri = "http://sales.fourthcoffee.com/SalesService.svc/GetSalesPerson";
                    var rawData = Encoding.Default.GetBytes("{\"emailAddress\":\"jesper@fourthcoffee.com\"}");
                    // Create the request object.
                    var request = WebRequest.Create(uri) as HttpWebRequest;
                    // Configure the type of data the request will send.
                    request.Method = "POST";
                    request.ContentType = "application/json";
                    request.ContentLength = rawData.Length;
                    // Stream the data to the request.
                    var dataStream = request.GetRequestStream();
                    dataStream.Write(rawData, 0, rawData.Length);
                    dataStream.Close();
                }

                Console.WriteLine("** Uploading a File to an FTP Site");
                {
                    // Get the URI and the data.  
                    var uri = "ftp://sales.fourthcoffee.com/FileRepository/SalesForcast.xls";
                    var rawData = File.ReadAllBytes("C:\\FourthCoffee\\Documents\\SalesForecast.xls");
                    // Create the request object.
                    var request = WebRequest.Create(uri) as FtpWebRequest;
                    // Configure the type of data the request will send.
                    request.Method = WebRequestMethods.Ftp.UploadFile;
                    request.ContentLength = rawData.Length;
                    // Stream the data to the request.
                    var dataStream = request.GetRequestStream();
                    dataStream.Write(rawData, 0, rawData.Length);
                    dataStream.Close();
                }

                Console.WriteLine("** Reading Data from the Response");
                {
                    var uri = "http://sales.fourthcoffee.com/SalesService.svc/GetSalesPerson";
                    var request = WebRequest.Create(uri) as HttpWebRequest;

                    var response = request.GetResponse() as HttpWebResponse;
                    var stream = new StreamReader(response.GetResponseStream());
                    // Code to process the stream.
                    stream.Close();
                }
            }
        }

        public static void UsingDataService()
        {
            /*
            
            https://docs.microsoft.com/en-us/dotnet/framework/data/wcf/index

            WCF Data Services follows the Representational State Transfer (REST) architectural model and 
            uses open web standards such as the Open Data Protocol (OData) to expose and consume data over 
            the web. By following these standards, you can build solutions based on WCF Data Services that 
            a wide variety of client applications can easily access, regardless of the technology that is 
            used to implement the client application. 

            WCF Data Services enables you to create and access data services over the web. You expose your 
            data as resources that applications can access by using a URI. These resources are exposed as 
            sets of entities that are related by associations, the same concepts as in an EDM. However, you 
            can expose data from many types of storage, including databases and Common Language Runtime 
            (CLR) classes. 

            WCF Data Services uses URIs to address data and simple, well-known formats to represent that 
            data, such as XML and Atom. This results in data being served as a REST-style resource 
            collection. 

            REST has become a popular model for implementing web services that need to access data (other 
            models, such as those based on the WebRequest/WebResponse model described in the previous
            lesson, are more suited to invoking remote methods). REST describes a stateless, 
            hierarchical scheme for representing resources and business objects over a network. 
            Resources are accessed through URIs that identify the data to retrieve. For example, Fourth 
            Coffee might choose to make the data for all of its sales people available through the 
            following URI: 
            
                http://FourthCoffee.com/SalesService.svc/SalesPersons

            The data for a specific sales person could be fetched by specifying the identifier (such as a 
            sales person number) for that sales person, like this: 

                http://FourthCoffee.com/SalesService.svc/SalesPersons/99

            Similarly, the details of products that it sells might be available through the following URI: 

                http://FourthCoffee.com/SalesService.svc/Products

            The details for a specific product could be retrieved by including the product ID in the URI: 

                http://FourthCoffee.com/SalesService.svc/Products/25
            
            The REST model performs HTTP GET queries to retrieve data, but the REST model also supports 
            insert, update, and delete operations by using HTTP PUT, POST, and DELETE requests.

            The REST model enables a web service to extend URIs to support filtering, sorting, and paging 
            of data. For example, the following URI sends a request that fetches the first 10 sales people 
            only: 
            
                http://FourthCoffee.com/SalesService.svc/SalesPersons?top=10

            The list of filters and other functionality depends on how the web service is implemented, but 
            features such as these are available with WCF Data Services. Additionally, WCF Data Services 
            enables you to extend your web services by writing service operations as methods that perform 
            business logic at the server. These methods are then accessible as URIs in a similar manner to 
            resources. You can also define interceptors, which are called when you query, insert, update,
            or delete data and can validate or modify the data, enforce security, or reject the change. 

            By using WCF Data Services, you can expose data from relational data sources such as Microsoft 
            SQL Server® through an EDM conceptual schema that is created by using the ADO.NET Entity 
            Framework, and you can enable a client application to query and maintain data by using this 
            schema. 

            A WCF Data Service is based on the System.Data.Services.DataService generic class. This class
            expects a type parameter that is a collection containing at least one property that implements 
            the IQueryable interface, such as the DbContext class for an entity set that is defined by 
            using the Entity Framework. The DataService type implements the basic functionality to expose 
            the entities in this collection as a series of REST resources. 

            You can implement methods in a WCF Data Service that specify the entities to expose from the 
            underlying EDM and that configure the size of datasets that the data service presents. You can
            also override methods that are inherited from the DataService class to customize the way in 
            which the service operates. 

            By default, WCF Data Services uses a simple addressing scheme that exposes the entity sets 
            that are defined within the specified EDM. When you consume a WCF Data Service, you address 
            these entity resources as an entity set that contains instances of an entity type. For 
            example, suppose that the following URI (shown in the previous topic) returns all of the 
            SalesPerson entities that were defined in the EDM that was used to construct a WCF Data 
            Service: 

                http://FourthCoffee.com/SalesService.svc/SalesPersons

            The "/SalesPersons" element of the URI points to the SalesPersons entity set, which is the 
            container for SalesPerson instances.

            For security reasons, WCF Data Services does not automatically expose any resources, such as 
            entity collections, that the EDM implements. You specify a policy that enables or disables 
            access to resources in the InitializeService method of your data service. This method takes 
            a DataServiceConfiguration object, which has a SetEntitySetAccessRule property that you use 
            to define the access policy. 

            */
            Console.WriteLine("* Using DataService");
            {
                var dataLoader = new SalesDataLoader(
                    new Uri("http://localhost:51432/SalesService.svc/GetSalesPerson"));

                var result = dataLoader.GetPersonByEmail("jesper@fourthcoffee.com");

                if (result == null)
                {
                    Console.WriteLine("Could not find a record.");
                }
                else
                {
                    Console.WriteLine("Record loaded.");

                    Console.WriteLine(string.Format("{0} {1}", result.FirstName, result.Surname));
                    Console.WriteLine(result.Area);
                    Console.WriteLine(result.EmailAddress);
                }
            }

            Console.WriteLine("* Using REST");
            {
                /*
                
                The specified OData API cannot be added because OData APIs are now only supported with Connected Services.

                For more information, please see: https://aka.ms/odatavsclientguidance

                "%windir%\Microsoft.NET\Framework\v4.0.30319\DataSvcUtil.exe" /dataservicecollection /version:2.0 /language:CSharp /out:"d:\Workspace\clu.active.learning\clu.active.learning\Service References\ServiceReference.cs" /uri:http://localhost:51432/GradesService.svc

                */

                SchoolGradesDBEntities dbContext = new SchoolGradesDBEntities(new Uri("http://localhost:51432/GradesService.svc"));

                IQueryable<Student> students = from student in dbContext.Students
                                               select student;
                foreach (var student in students)
                {
                    Console.WriteLine("{0} {1}", student.FirstName, student.LastName);
                }
            }
        }

        #endregion
    }
}