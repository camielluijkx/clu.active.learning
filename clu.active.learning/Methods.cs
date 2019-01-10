using System;

namespace clu.active.learning
{
    public static class Methods
    {
        #region Public Methods

        public static void UsingMethods()
        {
            {
                Console.WriteLine("* Using Methods");
                {
                    ServiceConfiguration config = new ServiceConfiguration(); // initialize

                    var loadResult = config.LoadConfiguration(); // invoke method
                    config.StartService(100, true); // invoke method with parameters

                    var servicesCount = 0;
                    config.StopAllServices(ref servicesCount); // invoke method with reference parameter
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
                        config.StartService3(out var anotherService); // define parameter inline
                    }
                }
            }
        }

        #endregion
    }
}
