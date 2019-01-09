using System;

namespace clu.active.learning
{
    public static class Properties
    {
        #region Public Methods

        public static void UseProperties()
        {
            {
                Console.WriteLine("** Use Properties");
                ServiceConfiguration config = new ServiceConfiguration(); // initialize

                var applicationName = config.ApplicationName; // get property

                config.ApplicationUser = "clu"; // set property
            }
        }

        // TODO (fields, private set, indexers)

        #endregion
    }
}
