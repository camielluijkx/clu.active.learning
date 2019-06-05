using System;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/api/system.security.permissions.principalpermission?view=netframework-4.8

    */
    public class PrincipalPermission
    {
        public static void Test()
        {
            AppDomain.CurrentDomain.SetPrincipalPolicy(System.Security.Principal.PrincipalPolicy.WindowsPrincipal);
            System.Security.Permissions.PrincipalPermission principalPerm = new System.Security.Permissions.PrincipalPermission(null, "Administrators");
            principalPerm.Demand();
            Console.WriteLine("Demand succeeded.");

            Console.ReadLine();
        }
    }
}