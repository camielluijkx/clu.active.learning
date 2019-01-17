using System;
using Tasks = System.Threading.Tasks;

namespace clu.active.learning
{
    /*
    
    System.Windows      Provides the classes that are useful for building WPF applications.                
    System.IO           Provides classes for reading and writing data to files.
    System.Data         Provides classes for data access.
    System.Web          Provides classes that are useful for building web applications.
    etc.

    */
    public static class Namespaces
    {
        #region Public Methods

        public static void UsingNamespaces()
        {
            Console.WriteLine("* Using Namespaces");
            {
                Tasks.Task.Factory.StartNew(() => 
                {
                    Console.WriteLine("do something");
                });
                System.Threading.Tasks.Task.Factory.StartNew(() => 
                {
                    Console.WriteLine("do something else");
                });
            }
        }

        #endregion
    }
}
