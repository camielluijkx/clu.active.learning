using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Reflection;
using System.Runtime.Serialization;
using System.Xml;
using System.Xml.Schema;
using System.Xml.Serialization;

namespace clu.active.learning.console
{
    /*

    https://docs.microsoft.com/en-us/dotnet/api/system.runtime.serialization.idatacontractsurrogate?view=netframework-4.8

    https://docs.microsoft.com/en-us/dotnet/framework/wcf/extending/data-contract-surrogates

    */
    public class DataContractSurrogate
    {
        [DataContract()]
        public class Employee
        {
            [DataMember()]
            public DateTime DateHired { get; set; }

            [DataMember()]
            public decimal Salary { get; set; }

            [DataMember()]
            public Person Person { get; set; }
        }

        public class Person
        {
            [XmlElement("FirstName")]
            public string FirstName { get; set; }

            [XmlElement("LastName")]
            public string LastName { get; set; }

            [XmlAttribute("Age")]
            public Int16 Age { get; set; }

            public Person()
            {

            }
        }

        [DataContract]
        public class PersonSurrogated
        {
            [DataMember()]
            public string XmlData { get; set; }
        }

        public class LegacyPersonTypeSurrogate : IDataContractSurrogate
        {
            public Type GetDataContractType(Type type)
            {
                Console.WriteLine("GetDataContractType invoked");
                Console.WriteLine("\t type name: {0}", type.Name);
                // "Person" will be serialized as "PersonSurrogated"
                // This method is called during serialization,
                // deserialization, and schema export.
                if (typeof(Person).IsAssignableFrom(type))
                {
                    Console.WriteLine("\t returning PersonSurrogated");
                    return typeof(PersonSurrogated);
                }
                return type;
            }

            public object GetObjectToSerialize(object obj, Type targetType)
            {
                Console.WriteLine("GetObjectToSerialize Invoked");
                Console.WriteLine("\t type name: {0}", obj.ToString());
                Console.WriteLine("\t target type: {0}", targetType.Name);
                // This method is called on serialization.
                // If Person is not being serialized...
                if (obj is Person)
                {
                    Console.WriteLine("\t returning PersonSurrogated");
                    // ... use the XmlSerializer to perform the actual serialization.
                    PersonSurrogated ps = new PersonSurrogated();
                    XmlSerializer xs = new XmlSerializer(typeof(Person));
                    StringWriter sw = new StringWriter();
                    xs.Serialize(sw, (Person)obj);
                    ps.XmlData = sw.ToString();
                    return ps;
                }
                return obj;

            }

            public object GetDeserializedObject(Object obj, Type targetType)
            {
                Console.WriteLine("GetDeserializedObject invoked");
                // This method is called on deserialization.
                // If PersonSurrogated is being deserialized...
                if (obj is PersonSurrogated)
                {
                    //... use the XmlSerializer to do the actual deserialization.
                    PersonSurrogated ps = (PersonSurrogated)obj;
                    XmlSerializer xs = new XmlSerializer(typeof(Person));
                    return (Person)xs.Deserialize(new StringReader(ps.XmlData));
                }
                return obj;

            }

            public Type GetReferencedTypeOnImport(string typeName,
                string typeNamespace, object customData)
            {
                Console.WriteLine("GetReferencedTypeOnImport invoked");
                // This method is called on schema import.
                // If a PersonSurrogated data contract is 
                // in the specified namespace, do not create a new type for it 
                // because there is already an existing type, "Person".
                Console.WriteLine("\t Type Name: {0}", typeName);

                if (typeName.Equals("PersonSurrogated"))
                {
                    Console.WriteLine("Returning Person");
                    return typeof(Person);
                }
                return null;
            }

            public System.CodeDom.CodeTypeDeclaration ProcessImportedType(
                System.CodeDom.CodeTypeDeclaration typeDeclaration,
                System.CodeDom.CodeCompileUnit compileUnit)
            {
                // Console.WriteLine("ProcessImportedType invoked")
                // Not used in this sample.
                // You could use this method to construct an entirely new CLR 
                // type when a certain type is imported, or modify a 
                // generated type in some way.
                return typeDeclaration;
            }

            public object GetCustomDataToExport(Type clrType, Type dataContractType)
            {
                // Not used in this sample
                return null;
            }

            public object GetCustomDataToExport(MemberInfo memberInfo, Type dataContractType)
            {
                // Not used in this sample
                return null;
            }

            public void GetKnownCustomDataTypes(Collection<Type> customDataTypes)
            {
                // Not used in this sample
            }
        }

        private static DataContractSerializer createSurrogateSerializer()
        {
            // Create an instance of the DataContractSerializer. The 
            // constructor demands a knownTypes and surrogate. 
            // Create a Generic List for the knownTypes. 
            List<Type> knownTypes = new List<Type>();
            LegacyPersonTypeSurrogate surrogate = new LegacyPersonTypeSurrogate();
            DataContractSerializer surrogateSerializer =
                new DataContractSerializer(typeof(Employee),
               knownTypes, Int16.MaxValue, false, true, surrogate);
            return surrogateSerializer;
        }

        private static void serializeWithSurrogate(string filename)
        {
            // Create and populate an Employee instance.
            Employee emp = new Employee();
            emp.DateHired = new DateTime(1999, 10, 14);
            emp.Salary = 33000;

            // Note that the Person class is a legacy XmlSerializable class
            // without a DataContract.
            emp.Person = new Person();
            emp.Person.FirstName = "Mike";
            emp.Person.LastName = "Ray";
            emp.Person.Age = 44;

            // Create a new writer. Then serialize with the 
            // surrogate serializer.
            FileStream fs = new FileStream(filename, FileMode.Create);
            DataContractSerializer surrogateSerializer = createSurrogateSerializer();
            try
            {
                surrogateSerializer.WriteObject(fs, emp);
                Console.WriteLine("Serialization succeeded. ");
                fs.Close();
            }
            catch (SerializationException exc)
            {
                Console.WriteLine(exc.Message);
            }
        }

        private static void deserializeSurrogate(string filename)
        {
            // Create a new reader object.
            FileStream fs2 = new FileStream(filename, FileMode.Open);
            XmlDictionaryReader reader =
                XmlDictionaryReader.CreateTextReader(fs2, new XmlDictionaryReaderQuotas());

            Console.WriteLine("Trying to deserialize with surrogate.");
            try
            {
                DataContractSerializer surrogateSerializer = createSurrogateSerializer();
                Employee newemp = (Employee)surrogateSerializer.ReadObject(reader, false);

                reader.Close();
                fs2.Close();

                Console.WriteLine("Deserialization succeeded. \n\n");
                Console.WriteLine("Deserialized Person data: \n\t {0} {1}",
                        newemp.Person.FirstName, newemp.Person.LastName);
                Console.WriteLine("\t Age: {0} \n", newemp.Person.Age);
                Console.WriteLine("\t Date Hired: {0}", newemp.DateHired.ToShortDateString());
                Console.WriteLine("\t Salary: {0}", newemp.Salary);
                Console.WriteLine("Press Enter to end or continue");
                Console.ReadLine();
            }
            catch (SerializationException serEx)
            {
                Console.WriteLine(serEx.Message);
                Console.WriteLine(serEx.StackTrace);
            }
        }

        private static void exportSchemas(string filename, ref XmlSchemaSet schemas)
        {
            Console.WriteLine("Now doing schema export.");
            // The following code demonstrates schema export with a surrogate.
            // The surrogate indicates how to export the non-DataContract Person type.
            // Without the surrogate, schema export would fail.
            XsdDataContractExporter xsdexp = new XsdDataContractExporter();
            xsdexp.Options = new ExportOptions();
            xsdexp.Options.DataContractSurrogate = new LegacyPersonTypeSurrogate();
            xsdexp.Export(typeof(Employee));

            // Write out the exported schema to a file.
            using (FileStream fs3 = new FileStream("sample.xsd", FileMode.Create))
            {
                foreach (XmlSchema sch in xsdexp.Schemas.Schemas())
                {
                    sch.Write(fs3);
                }
            }
        }

        private static void importSchemas(XmlSchemaSet schemas)
        {
            Console.WriteLine("Now doing schema import.");
            // The following code demonstrates schema import with 
            // a surrogate. The surrogate is used to indicate that 
            // the Person class already exists and that there is no 
            // need to generate a new class when importing the
            // PersonSurrogated data contract. If the surrogate 
            // was not used, schema import would generate a 
            // PersonSurrogated class, and the person field 
            // of Employee would be imported as 
            // PersonSurrogated and not Person.
            XsdDataContractImporter xsdimp = new XsdDataContractImporter();
            xsdimp.Options = new ImportOptions();
            xsdimp.Options.DataContractSurrogate = new LegacyPersonTypeSurrogate();
            xsdimp.Import(schemas);

            // Write out the imported schema to a C-Sharp file.
            // The code contains data contract types.
            FileStream fs4 = new FileStream("sample.cs", FileMode.Create);
            try
            {
                StreamWriter tw = new StreamWriter(fs4);
                Microsoft.CSharp.CSharpCodeProvider cdp = new Microsoft.CSharp.CSharpCodeProvider();
                cdp.GenerateCodeFromCompileUnit(xsdimp.CodeCompileUnit, tw, null);
                tw.Flush();
            }
            finally
            {
                fs4.Dispose();
            }
        }

        public static void Test()
        {
            serializeWithSurrogate("surrogateEmployee.xml");
            deserializeSurrogate("surrogateEmployee.xml");

            Console.ReadLine();
        }
    }
}