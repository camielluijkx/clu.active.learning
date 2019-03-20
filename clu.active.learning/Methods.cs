using System;

namespace clu.active.learning
{
    public static class Methods
    {
        #region Implementation

        public class ServiceConfiguration
        {
            public const int NumberOfServices = 3;

            public bool LoadConfiguration() // method without params
            {
                return true; // return a boolean value from method
            }

            public void SaveConfiguation() // method without params
            {
                // no return value
            }

            public void StartService(int uptime, bool shutdownAutomatically) // method with params
            {

            }

            public void StopAllServices(ref int servicesCount) // method with reference param
            {
                servicesCount = NumberOfServices;
            }

            public void StopAllServices(int servicesCount)
            {

            }

            //CS0663: Cannot define overloaded methods that differ only on ref and out.
            //public void StopAllServices(in int servicesCount) { } // introduced in Visual C# 7.2
            //public void StopAllServices(out int servicesCount) { }

            public void StopAllServices(int servicesCount, bool forceStop = true) // optional param with default value
            {
                servicesCount = NumberOfServices;
            }

            //CS1737: Optional parameters must appear after all required parameters.
            //public void StopAllServices(bool forceStop = true, int servicesCount) { }

            public void StartAllServices(bool forceStart = true) // optional param with default value
            {
            } 

            public void StartService(int serviceId)
            {

            }

            public void StartService(string serviceName, bool forceStart) // overload (same name, different signature)
            {
                // The return type of a method does not form part of a methods signature.
            }

            public void StartService1(in string serviceName)
            {
                //serviceName += " IN"; 
                //CS8331: Cannot assign to variable 'in string' because it is a readonly variable.
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
                //serviceName += " OUT"; 
                //CS0177: The out parameter 'serviceName' must be assigned to before control leaves the current method.
                serviceName = "Service 3";
                serviceName += " OUT";
                var serviceToStart = serviceName;
                Console.WriteLine(serviceToStart);
            }
        }

        #endregion

        #region Public Methods

        public static void UsingMethods()
        {
            Console.WriteLine("* Using Methods");
            {
                ServiceConfiguration config = new ServiceConfiguration(); // initialize

                var loadResult = config.LoadConfiguration(); // invoke method
                config.StartService(100, true); // invoke method with parameters

                var servicesCount = 0;
                config.StopAllServices(ref servicesCount); // invoke method with reference param
                Console.WriteLine(servicesCount);

                Console.WriteLine("** Optional Parameters");
                {
                    config.StopAllServices(3);
                    config.StopAllServices(3, false); // forceStop = false
                    config.StopAllServices(3, true); // forceStop = true
                    config.StartAllServices(); // forceStart = true
                    config.StartAllServices(true); // forceStart = true
                    config.StartAllServices(false); // forceStart = false
                }

                Console.WriteLine("** Named Parameters");
                {
                    config.StartService(forceStart: true, serviceName: "Service");
                    config.StartService("Service", forceStart: true);
                    config.StartService(serviceName: "Service", true);
                }

                Console.WriteLine("** In vs Ref vs Out");
                {
                    var service1 = "Service 1";
                    config.StartService1(service1);
                    config.StartService1(in service1); // in is optional
                    var service2 = "Service 2";
                    config.StartService2(ref service2); // ref must be supplied
                    var service3 = "Service 3";
                    config.StartService3(out service3); // out must be applied
                }

                Console.WriteLine("** Output Parameters");
                {
                    config.StartService3(out var anotherService); // define param inline
                }

                // TODO: params argument
            }
        }

        #endregion
    }
}