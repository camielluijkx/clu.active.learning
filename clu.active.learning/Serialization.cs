using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization.Formatters.Soap;
using System.Runtime.Serialization.Json;

namespace clu.active.learning
{
    /*
    
    Serialization is the process of converting data to a format that can be persisted or transported. 
    
    Deserialization is the process of converting serialized data back to objects.
    
    Serializable Formats

    The requirements of your system, and how you intend to transport the data, will influence the serialization format 
    you choose. The following table describes some of the common formats available.

    Format          Description
    Binary          Serializing data into the machine-readable binary format enables you to preserve the fidelity and 
                    state of an object between different instances of your application. Binary serialization is also 
                    fast and lightweight, because the binary format does not require the processing and storage of 
                    unnecessary formatting constructs. Binary serialization is commonly used when persisting and 
                    transporting objects between applications running on the same platform.
    XML             Serializing data into the XML format enables you to utilize an open standard that can be processed 
                    by any application, regardless of platform. In contrast to binary, XML does not preserve type 
                    fidelity; it only lets you serialize public members that your type exposes. The XML format is more 
                    verbose than binary, as the serialized data is formatted with XML constructs. This makes the XML 
                    format less efficient and more processor intensive during the serializing, deserializing, and 
                    transporting processes. However, the nature of XML as a plain text and free-form language allows 
                    messages to be transmitted across different applications and platforms. So long as the transmitter 
                    and receiver have agreed on a known contract, both can send and receive messages and convert them 
                    to the appropriate model within their respective environments. XML serialization was commonly used 
                    to serialize data that can be transported via the SOAP protocol to and from web services. However, 
                    due to SOAP’s verbose and strict nature, this protocol has fallen out of favor, and is generally 
                    found today only in legacy environments.
    JSON            Serializing data into the JSON format enables you to utilize a lightweight, data-interchange format 
                    that is based on a subset of the JavaScript programming language. JSON is a simple text format that 
                    is human readable and also easy to parse by machine, irrespective of platform. JSON shares XML 
                    strengths as plain text and free form, making it cross platform. However, unlike XML, it has a much 
                    more concise syntax, which makes it cheaper to transmit and human readable. These advantages made 
                    JSON the prevalent language to transmit data today, and the de-facto standard in today’s industry. 
                    JSON is commonly used to transport data between everything from Asynchronous JavaScript and XML 
                    (AJAX) calls to messages between webservices, because unlike SOAP, you are not limited to just 
                    communicating within the same domain.

    Alternatively, if you want to serialize your data to a format that the .NET Framework does not natively support, 
    you can implement your own custom serializer class.

    */
    public static class Serialization
    {
        #region Implementation

        // Creating a Serializable Type.
        [Serializable]
        public class ServiceConfiguration : ISerializable
        {
            [NonSerialized] // ignore fields
            private Guid _internalId;

            public string ConfigName { get; set; }
            public string DatabaseHostName { get; set; }
            public string ApplicationDataPath { get; set; }

            // Default constructor is mandatory.
            public ServiceConfiguration()
            {
            }

            // Rehydrate object during deserialization process.
            public ServiceConfiguration(SerializationInfo info, StreamingContext ctxt)
            {
                this.ConfigName = info.GetValue("ConfigName", typeof(string)).ToString();
                this.DatabaseHostName = info.GetValue("DatabaseHostName", typeof(string)).ToString();
                this.ApplicationDataPath = info.GetValue("ApplicationDataPath", typeof(string)).ToString();
            }

            public static ServiceConfiguration Default
            {
                get
                {
                    return new ServiceConfiguration
                    {
                        ConfigName = "SomeConfigName",
                        DatabaseHostName = "SomeDatabaseHostName",
                        ApplicationDataPath = "SomeApplicationDataPath"
                    };
                }
            }

            // Extract data from object during serialization process.
            public void GetObjectData(SerializationInfo info, StreamingContext context) 
            {
                info.AddValue("ConfigName", this.ConfigName);
                info.AddValue("DatabaseHostName", this.DatabaseHostName);
                info.AddValue("ApplicationDataPath", this.ApplicationDataPath);
            }
        }

        public class ServiceConfigurationUsingJsonNet
        {
            // JsonConvert ignores private members by default
            private Guid _internalId;

            // Map the properties with json naming conventions
            [JsonProperty("configName")]
            public string ConfigName { get; set; }
            [JsonProperty("databaseHostName")]
            public string DatabaseHostName { get; set; }
            [JsonProperty("applicationDataPath")]
            public string ApplicationDataPath { get; set; }
        }

        // Creating a Custom Serializer.
        public class IniFormatter : IFormatter
        {
            static readonly char[] _delim = new char[] { '=' };

            public ISurrogateSelector SurrogateSelector { get; set; }
            public SerializationBinder Binder { get; set; }
            public StreamingContext Context { get; set; }

            public IniFormatter()
            {
                this.Context = new StreamingContext(StreamingContextStates.All);
            }

            public object Deserialize(Stream serializationStream)
            {
                StreamReader buffer = new StreamReader(serializationStream);

                // Get the type from the serialized data.
                Type typeToDeserialize = this.GetType(buffer);

                // Create default instance of object using type name.
                Object obj = FormatterServices.GetUninitializedObject(typeToDeserialize);

                // Get all the members for the type.
                MemberInfo[] members = FormatterServices.GetSerializableMembers(obj.GetType(), this.Context);

                // Create dictionary to store the variable names and any serialized data.
                Dictionary<string, object> serializedMemberData = new Dictionary<string, object>();

                // Read the serialized data, and extract the variable names and values as strings.
                while (buffer.Peek() >= 0)
                {
                    string line = buffer.ReadLine();
                    string[] sarr = line.Split(_delim);

                    // key = variable name, value = variable value
                    serializedMemberData.Add(
                       sarr[0].Trim(),   // Variable name. 
                       sarr[1].Trim());  // Variable value.
                }

                // Close the underlying stream.
                buffer.Close();

                // Create a list to store member values as their correct type.
                List<object> dataAsCorrectTypes = new List<object>();

                // For each of the members, get the serialized values as their correct type.
                for (int i = 0; i < members.Length; i++)
                {
                    FieldInfo field = members[i] as FieldInfo;
                    if (!serializedMemberData.ContainsKey(field.Name))
                    {
                        throw new SerializationException(field.Name);
                    }

                    // Change the type of the value to the correct type of the member.
                    object valueAsCorrectType = Convert.ChangeType(serializedMemberData[field.Name], field.FieldType);
                    dataAsCorrectTypes.Add(valueAsCorrectType);
                }

                // Populate the object with the deserialized values.
                return FormatterServices.PopulateObjectMembers(obj, members, dataAsCorrectTypes.ToArray());
            }

            public void Serialize(Stream serializationStream, object graph)
            {
                // Get all the fields that you want to serialize.
                MemberInfo[] allMembers = FormatterServices.GetSerializableMembers(graph.GetType(), this.Context);

                // Get the field data.
                object[] fieldData = FormatterServices.GetObjectData(graph, allMembers);

                // Create a buffer to write the serialized data too.
                StreamWriter sw = new StreamWriter(serializationStream);

                // Write the name of the class to the firstline.
                sw.WriteLine("@ClassName={0}", graph.GetType().FullName);

                // Iterate the field data.
                for (int i = 0; i < fieldData.Length; ++i)
                {
                    sw.WriteLine("{0}={1}",
                        allMembers[i].Name,        // Member name.
                        fieldData[i].ToString());  // Member value.
                }
                sw.Close();
            }

            private Type GetType(StreamReader buffer)
            {
                string firstLine = buffer.ReadLine();
                string[] sarr = firstLine.Split(_delim);
                string nameOfClass = sarr[1];

                return Type.GetType(nameOfClass);
            }
        }

        #endregion

        #region Public Methods

        public static void UsingSerialization()
        {
            Console.WriteLine("* Using Serialization");
            {
                Console.WriteLine("** Serialize an Object using the BinaryFormatter");
                {
                    // Create the object you want to serialize.
                    ServiceConfiguration config = ServiceConfiguration.Default;

                    // Create the formatter you want to use to serialize the object.
                    IFormatter formatter = new BinaryFormatter();

                    // Create the stream that the serialized data will be buffered to.
                    FileStream buffer = File.Create(@"C:\fourthcoffee\config.txt");

                    // Invoke the Serialize method.
                    formatter.Serialize(buffer, config);

                    // Close the stream.
                    buffer.Close();
                }

                Console.WriteLine("** Deserialize an Object using the BinaryFormatter");
                {
                    // Create the formatter you want to use to serialize the object.
                    IFormatter formatter = new BinaryFormatter();

                    // Create the stream that the serialized data will be buffered too.
                    FileStream buffer = File.OpenRead(@"C:\fourthcoffee\config.txt");

                    // Invoke the Deserialize method.
                    ServiceConfiguration config = formatter.Deserialize(buffer) as ServiceConfiguration;

                    // Close the stream.
                    buffer.Close();
                }

                Console.WriteLine("** Serialize an Object using the SoapFormatter");
                {
                    // Create the object you want to serialize.
                    ServiceConfiguration config = ServiceConfiguration.Default;

                    // Create the formatter you want to use to serialize the object.
                    IFormatter formatter = new SoapFormatter();

                    // Create the stream that the serialized data will be buffered too.
                    FileStream buffer = File.Create(@"C:\fourthcoffee\config.xml");

                    // Invoke the Serialize method.
                    formatter.Serialize(buffer, config);

                    // Close the stream.
                    buffer.Close();
                }

                Console.WriteLine("** Deserialize an Object using the SoapFormatter");
                {
                    // Create the formatter you want to use to serialize the object.
                    IFormatter formatter = new SoapFormatter();

                    // Create the stream that the serialized data will be buffered too.
                    FileStream buffer = File.OpenRead(@"C:\fourthcoffee\config.xml");

                    // Invoke the Deserialize method.
                    ServiceConfiguration config = formatter.Deserialize(buffer) as ServiceConfiguration;

                    // Close the stream.
                    buffer.Close();
                }

                Console.WriteLine("** Serialize an Object using the DataContractJsonSerializer");
                {
                    // Create the object you want to serialize.
                    ServiceConfiguration config = ServiceConfiguration.Default;

                    // Create a DataContractJsonSerializer object that you will use to serialize the object to JSON. 
                    // DataContractJsonSerializer class is derived from the abstract XmlObjectSerializer class, and it 
                    // is not an implementation of the IFormatter interface.
                    DataContractJsonSerializer jsonSerializer = new DataContractJsonSerializer(config.GetType());

                    // Create the stream that the serialized data will be buffered too.
                    FileStream buffer = File.Create(@"C:\fourthcoffee\config.txt");

                    // Invoke the WriteObject method.
                    jsonSerializer.WriteObject(buffer, config);

                    // Close the stream.
                    buffer.Close();
                }

                Console.WriteLine("** Deserialize an Object using the DataContractJsonSerializer");
                {
                    // Create a DataContractJsonSerializer object that you will use to deserialize the JSON.
                    DataContractJsonSerializer jsonSerializer 
                        = new DataContractJsonSerializer(typeof(ServiceConfiguration));

                    // Create a stream that will read the serialized data.
                    FileStream buffer = File.OpenRead(@"C:\fourthcoffee\config.txt");

                    // Invoke the ReadObject method.
                    ServiceConfiguration config = jsonSerializer.ReadObject(buffer) as ServiceConfiguration;

                    // Close the stream.
                    buffer.Close();
                }

                Console.WriteLine("** Serialize an Object using the JsonConvert");
                {
                    /*
                    
                    Unlike the .NET implementations of the IFormatter interface, JsonConvert doesn’t require the data 
                    class to be decorated with the Serializable attribute. Any class can be converted to JSON without 
                    special treatment. However, Json.NET does provide a set of attributes to specify exactly how the 
                    model will be serialized, if necessary. The most useful of them is perhaps the JsonProperty 
                    attribute, which allows to determine the name of the property in the serialized JSON string.

                    */

                    // Create the object you want to serialize.
                    ServiceConfiguration config = ServiceConfiguration.Default;
                    var jsonString = JsonConvert.SerializeObject(config);
                }

                Console.WriteLine("** Deserialize an Object using the JsonConvert");
                {
                    // Get the JSON string – Here we’re assuming it’s the same from the previous example.
                    ServiceConfiguration config = ServiceConfiguration.Default;
                    var jsonString = JsonConvert.SerializeObject(config);

                    // Deserialize to the desired type.
                    var deserializedConfig = JsonConvert.DeserializeObject<ServiceConfiguration>(jsonString);
                }

                Console.WriteLine("** Serialize an Object using the JsonSerializer");
                {
                    // Create the serializer.
                    var serializer = new JsonSerializer();

                    // Open the stream to the file.
                    var fileWriter = File.CreateText(@"C:\fourthcoffee\config.json");

                    // Serialize and write the object to the file
                    ServiceConfiguration config = ServiceConfiguration.Default;
                    serializer.Serialize(fileWriter, config);

                    // Close the stream.
                    fileWriter.Close();
                    fileWriter.Dispose();
                }

                Console.WriteLine("Deserialize an Object using the JsonSerializer");
                {
                    // Create the serializer.
                    var serializer = new JsonSerializer();

                    // Open a stream to the file.
                    var fileReader = File.OpenRead(@"C:\fourthcoffee\config.json");

                    // Create a stream and json text readers.
                    var textReader = new StreamReader(fileReader);
                    var jsonReader = new JsonTextReader(textReader);

                    // Deserialize to the desired type.
                    var deserializedConfig = serializer.Deserialize<ServiceConfiguration>(jsonReader);

                    // Close all the readers and the stream.
                    jsonReader.Close();
                    textReader.Close();
                    textReader.Dispose();
                    fileReader.Close();
                    fileReader.Dispose();
                }

                Console.WriteLine("** Difference between Json.NET vs .NET Serializers");
                {
                    // https://www.newtonsoft.com/json/help/html/JsonNetVsDotNetSerializers.htm
                }
            }
        }

        #endregion
    }
}