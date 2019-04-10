using System;

namespace clu.active.learning
{
    /*
     
    When you finish developing an application, you should sign and version the assembly before you distribute it to users. You must also consider how 
    and where the assembly is going to be installed. 
    
    An assembly is a collection of types and resources that form a unit of functionality. An assembly might consist of a single portable executable 
    (PE) file, such as an executable (.exe) program or dynamic link library (.dll) file, or it might consist of multiple PE files and external resource 
    files, such as bitmaps or data files. An assembly is the building block of a .NET Framework application because an application consists of one or 
    more assemblies. 

    An assembly consists of the following components:

        • Intermediate language (IL) code. The compiler translates the source code into IL, which is the set of instructions that the just-in-time 
          (JIT) compiler then translates to CPU-specific code before the application runs. 
        • Resources. These include images and assembly metadata. Assembly metadata exists in the form of the assembly manifest. 
        • Type metadata. Type metadata provides information about available classes, interfaces, methods, and properties, similar to the way that a 
          type library provides information about COM components. 
        • The assembly manifest. This contains assembly metadata and provides information about the assembly such as the title, the description, and 
           version information. The manifest also contains information about links to the other files in the assembly. The information in the manifest 
           is used at run time to resolve references and validate loaded assemblies. The assembly manifest can be stored in a separate file but is often 
           part of one of the PE files. 

    https://docs.microsoft.com/en-us/dotnet/framework/app-domains/assemblies-in-the-common-language-runtime

    */
    public static class Assemblies
    {
        #region Public Methods

        public static void BoundariesOfAssemblies()
        {
            /*
            
            By arranging your code into assemblies, you create a set of boundaries that you can use to isolate configuration to a particular assembly. 
            The following list describes some of the boundaries that assemblies provide:

                • Security boundary. You set security permissions at an assembly level. You can use these permissions to request specific access for 
                  an application, for example, file I/O permissions if the application must write to a disk. When the assembly is loaded at run time, 
                  the permissions that are requested are entered into the security policy and used to determine whether permissions can be granted. 
                • Type boundary. An assembly provides a boundary for data types, because each type has the assembly name as part of its identity. As 
                  a result, two types can have the same name in different assemblies without any conflict. 
                • Reference scope boundary. An assembly provides a reference scope boundary by using the assembly manifest to resolve type and resource 
                  requests. This metadata specifies which types and resources are exposed outside the assembly. 

            */
            Console.WriteLine("* Boundaries of Assemblies");
            {

            }
        }

        public static void BenefitsOfAssemblies()
        {
            /*
            
            Assemblies provide you with the following benefits:

                • Single units of deployment. The client application loads assemblies when it needs them, which enables a minimal download strategy 
                  where appropriate. 
                • Versioning. An assembly is the smallest unit in a .NET Framework application that you can version. The assembly manifest describes 
                  the version information and any version dependencies that are specified for any dependent assemblies. You can only version assemblies 
                  that have strong names.

            */
            Console.WriteLine("* Benefits of Assemblies");
            {

            }
        }

        public static void UsingGAC()
        {
            /*
            
            When you create an assembly, by default you create a private assembly that a single application can use. If you need to create an assembly 
            that multiple applications can share, you should give the assembly a strong name and install the assembly into the GAC. 

            A strong name is a unique name for an assembly that consists of the assembly’s name, version number, culture information, and a digital 
            signature that contains a public and private key. 

            The GAC stores the assemblies that you want to share between multiple applications. When you add an assembly to the GAC, the GAC performs 
            integrity checks on all of the files that form the assembly. These checks ensure that nothing has tampered with an assembly. For example, 
            the GAC checks for changes to a file that the manifest does not reflect. 

            You can examine the GAC by using File Explorer. Browse to C:\Windows\assembly to see the list of assemblies in the GAC. The information in 
            the list of installed assemblies includes the following: 

                • The global assembly name
                • The version number of the assembly
                • The culture of the assembly, if applicable
                • The public key token of the assembly in the strong name
                • The type of assembly

            */
            Console.WriteLine("* Using GAC");
            {
                /*
                
                Although you can install strong-named assemblies in directories on the computer, the GAC offers several benefits, including the 
                following: 

                    • Side-by-side deployment and execution. Different versions of an assembly in the GAC do not affect each other. Therefore, 
                      applications that reference different versions of an assembly do not fail if a later incompatible version of the assembly is 
                      installed into the cache. 
                    • Improved loading time. When you install a strong-named assembly in the GAC, it undergoes strong-name validation, which ensures 
                      that the digital signature is valid. The verification process occurs at installation time, so strong-named assemblies in the GAC 
                      load faster at run time than assemblies that are not installed in the GAC. 
                    • Reduced memory consumption. If multiple applications reference an assembly, the operating system loads only one instance of the 
                      assembly, which can reduce the total memory that is used on the computer. 
                    • Improved search time. The CLR can locate a strong-named assembly in the GAC faster than it can locate a strong-named assembly that 
                      is in a directory. This is because the runtime checks the GAC for a referenced assembly before it checks other locations. 
                    • Improved maintainability. With a single file that multiple applications share, you can easily make fixes that affect all of the 
                      applications. 

                */
                Console.WriteLine("** Benefits of Using the GAC");
                {

                }
            }
        }

        public static void SigningAssemblies()
        {
            /*
             
            When you sign an assembly, you give the assembly a strong name. A strong name provides an assembly with a globally unique name that 
            applications use when they reference your assembly. This ensures that no one else can compile an assembly with the same name as yours and 
            impersonate your assembly. This helps to avoid malicious code overwriting one of your assemblies and then being run from an application 
            that expects to be using your authentic code. 

            A strong name requires two cryptographic keys, a public key and a private key, known as a key pair. The compiler uses the key pair at build 
            time to create the strong name. The strong name consists of the simple text name of the assembly, the version number, optional culture 
            information, the public key, and a digital signature. 

            */
            Console.WriteLine("* Signing Assemblies");
            {
                /*
                
                You must have a key pair to sign an assembly with a strong name. To create a key pair, use the Strong Name tool (Sn.exe) that the 
                .NET Framework provides. To create a key pair file, perform the following steps: 

                    1. Open the Visual Studio command prompt.
                    2. In the Command Prompt window, use the Sn.exe tool with the K switch to create a new key file. The following code example shows 
                      how to create a new key file with the name FourthCoffeeKeyFile. 

                        sn -k FourthCoffeeKeyFile.snk

                After you have created a key file, you can then sign your assembly.

                */
                Console.WriteLine("** Creating Key Pairs");
                {

                }

                /*
                
                When you have created the key pair, you can then associate the key file with your assembly. You can achieve this using the Signing 
                tab in the project properties pane. When you specify a key file in the properties pane, Visual Studio adds the 
                AssemblyKeyFileAttribute attribute to the AssemblyInfo class in your application. 

                */
                Console.WriteLine("** Signing an Assembly");
                {
                    // [assembly: AssemblyKeyFileAttribute("FourthCoffeeKeyFile.snk")]
                }

                /*
                
                When you sign an assembly, you might not have access to a private key. For example, for security reasons, some organizations restrict 
                access to their private key to just a few individuals. The public key will generally be available because as its name implies, it is 
                publicly accessible. In this situation, you can use delayed signing at build time. You provide the public key and reserve space in the 
                PE file for the strong-name signature. However, you defer the addition of the private key until a later stage, typically just before 
                the assembly ships. 

                You can enable delay-signing on the Signing tab of the project properties window as follows: 

                    1. In Solution Explorer, right-click the project, and then click Properties. 
                    2. In the properties window of the project, click the Signing tab. 
                    3. Select the Sign the assembly check box. 
                    4. Specify a key file.
                    5. Select the Delay sign only check box. 

                https://docs.microsoft.com/en-us/dotnet/framework/app-domains/delay-sign-assembly

                */
                Console.WriteLine("** Delay Signing an Assembly");
                {

                }

                /*
                
                You cannot run or debug a delay-signed project. You can, however, use the Sn.exe tool with the -Vr option to skip verification, which 
                means that the identity of the assemblies will not be checked. However, you should only use this option at development time because it 
                creates a security vulnerability. 

                */
                Console.WriteLine("** Disabling Verification");
                {
                    // sn –Vr FourthCoffee.Core.dll
                }

                /*
                
                You can then submit the assembly to the signing authority of your organization for the actual strong-name signing. Use the –R option 
                with the Sn.exe tool to resign a delay-signed assembly. 

                */
                Console.WriteLine("** Signing an Assembly");
                {
                    // sn -R FourthCoffee.Core.dll sgKey.snk
                }
            }
        }

        public static void VersioningAssemblies()
        {
            /*
            
            All assemblies are given a version number by Visual Studio, which is typically 1.0.0.0. It is the responsibility of the developer to 
            increment the assembly’s version number as the assembly evolves. 

            It is important to version assemblies so that you can keep track of which version of your application users are using. Without a version 
            number, debugging and reproducing production issues can be difficult. 

            */
            Console.WriteLine("* Versioning Assemblies");
            {
                /*
                
                The version number of an assembly is a four-part string with the following format: 
                
                    <major version>.<minor version>.<build number>.<revision>. 
                    
                For example, version 1.2.3.0 indicates 1 as the major version, 2 as the minor version, 3 as the build number, and 0 as the revision 
                number. 

                The assembly manifest stores the version number along with other identity information such as the assembly name and public key. The 
                CLR uses the version number, in conjunction with the available configuration information, to load the proper version of a referenced 
                assembly. 

                By default, applications only run with the version of an assembly with which they were built. To change an application to use a 
                different version of an assembly, you can create a version policy in one of the configuration files: the application configuration file, 
                the publisher policy file, or the computer's administrator configuration file. 

                https://docs.microsoft.com/en-us/dotnet/framework/app-domains/assembly-versioning

                */
                Console.WriteLine("** Assembly Version Number");
                {

                }

                /*
                
                When you want to update a strong-named component without redeploying the client application that uses it, you can use a publisher 
                policy file to redirect a binding request to a newer instance of the component. 

                When a client application makes a binding request, the runtime performs the following tasks: 

                    • It checks the original assembly reference for the version to be bound.
                    • It checks the configuration files for version policy instructions.

                The following code example shows a publisher policy file. To redirect one version to another, use the <bindingRedirect> element. 
                The oldVersion attribute can specify either a single version or a range of versions. 
                
                For example, <bindingRedirect oldVersion="1.1.0.0-1.2.0.0" newVersion="2.0.0.0"/> specifies that the runtime should use version 
                2.0.0.0 instead of the assembly versions between 1.1.0.0 and 1.2.0.0. 

                */
                Console.WriteLine("** Redirecting Binding Requests");
                {
                    //<configuration>
                    //   <runtime>
                    //      <assemblyBinding xmlns="urn:schemas-microsoft-com:asm.v1">
                    //       <dependentAssembly>
                    //         <assemblyIdentity name="FourthCoffee.Core"
                    //                           publicKeyToken="32ab4ba45e0a69a1"
                    //                           culture="en-us" />
                    //         <bindingRedirect oldVersion="1.0.0.0"
                    //                          newVersion="2.0.0.0"/>
                    //       </dependentAssembly>
                    //      </assemblyBinding>
                    //   </runtime>
                    //</configuration>
                }
            }
        }

        public static void InstallingIntoGAC()
        {
            /*
            
            The GAC is a folder on file system where you can install your assemblies. You can install your assemblies into the GAC in a variety of 
            ways, which include the following: 

                • Global Assembly Cache tool (Gacutil.exe). You can use Gacutil.exe to add strong-named assemblies to the GAC and to view the contents 
                  of the GAC. Gacutil.exe is for development purposes. You should not use the tool to install production assemblies into the GAC. 
                • Microsoft Windows Installer 2.0. This is the recommended and most common way to add assemblies to the GAC. The installer provides 
                  benefits such as reference counting of assemblies in the GAC. 

            https://docs.microsoft.com/en-us/dotnet/framework/app-domains/gac

            */
            Console.WriteLine("* Installing into GAC");
            {
                /*
                
                To install an assembly into the GAC by using the Gacutil.exe command-line tool, perform the following steps: 

                    1. Open the Visual Studio command prompt as an administrator.
                    2. In the Command Prompt window, type the following command: 

                        gacutil –i "<pathToAssembly>"

                */
                Console.WriteLine("** Installing an Assembly into the GAC by Using Gacutil.exe");
                {

                }

                /*
                
                To view an assembly that is installed into the GAC by using the Gacutil.exe command-line tool, perform the following steps: 

                    1. Open the Visual Studio 2012 command prompt as an administrator.
                    2. In the Command Prompt window, type the following command: 

                        gacutil –l "<assemblyName>"

                */
                Console.WriteLine("** Viewing an Assembly in the GAC by Using Gacutil.exe");
                {

                }
            }
        }

        #endregion
    }
}
