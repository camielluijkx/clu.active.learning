using System;

namespace clu.active.learning
{
    public class ServiceConfiguration
    {
        public const int NumberOfServices = 3;

        public string ApplicationName // property
        {
            get
            {
                return "Active Learning";
            }
        }

        public string ApplicationUser { get; set; } // property

        public bool LoadConfiguration() // method
        {
            return true; // return a boolean value from method
        }

        public void SaveConfiguation() // method
        {
            // no return value
        }

        public void StartService(int uptime, bool shutdownAutomatically) // method with parameters
        {

        }

        public void StopAllServices(ref int servicesCount) // method with reference parameter
        {
            servicesCount = NumberOfServices;
        }

        public void StopAllServices(int servicesCount)
        {

        }

        //CS0663: Cannot define overloaded methods that differ only on ref and out.
        //public void StopAllServices(in int servicesCount) { } // C# 7.2
        //public void StopAllServices(out int servicesCount) { }

        public void StopAllServices(int servicesCount, bool forceStop = true) // method with optional parameter (default value = true)
        {
            servicesCount = NumberOfServices;
        }

        //CS1737: Optional parameters must appear after all required parameters.
        //public void StopAllServices(bool forceStop = true, int servicesCount) { }

        public void StartAllServices(bool forceStart = true) { } // method with optional parameter (default value = true)

        public void StartService(int serviceId)
        {

        }

        public void StartService(string serviceName, bool forceStart) // overloaded, same method name, unique signature
        {
            // The return type of a method does not form part of a methods signature.
        }

        public void StartService1(in string serviceName)
        {
            //serviceName += " IN"; //CS8331: Cannot assign to variable 'in string' because it is a readonly variable.
            var serviceToStart = $"{serviceName} IN";
            Console.WriteLine(serviceToStart);
        }

        public void StartService2(ref string serviceName)
        {
            serviceName += " REF";
            var serviceToStart = serviceName;
            Console.WriteLine(serviceToStart);
        }

        public void StartService3(out string serviceName)
        {
            //serviceName += " OUT"; //CS0177: The out parameter 'serviceName' must be assigned to before control leaves the current method.
            serviceName = "Service 3";
            serviceName += " OUT";
            var serviceToStart = serviceName;
            Console.WriteLine(serviceToStart);
        }
    }
}
