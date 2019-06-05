using System;
using System.Security.Cryptography;

namespace clu.active.learning.console
{
    /*
    
    https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.dataprotectionscope?view=netframework-4.8

    https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.memoryprotectionscope?view=netframework-4.8 
   
    */
    public class ProtectionScope
    {
        // Create byte array for additional entropy when using Protect method.
        private static byte[] _aditionalEntropy = { 9, 8, 7, 6, 5 };

        public static byte[] Protect(byte[] data)
        {
            try
            {
                // Encrypt the data using DataProtectionScope.CurrentUser. The result can be decrypted only by the same current user.
                return ProtectedData.Protect(data, _aditionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Data was not encrypted. An error occurred.");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static byte[] Unprotect(byte[] data)
        {
            try
            {
                // Decrypt the data using DataProtectionScope.CurrentUser.
                return ProtectedData.Unprotect(data, _aditionalEntropy, DataProtectionScope.CurrentUser);
            }
            catch (CryptographicException e)
            {
                Console.WriteLine("Data was not decrypted. An error occurred.");
                Console.WriteLine(e.ToString());
                return null;
            }
        }

        public static void PrintValues(Byte[] myArr)
        {
            foreach (Byte i in myArr)
            {
                Console.Write("\t{0}", i);
            }
            Console.WriteLine();
        }

        public static void Test()
        {
            Console.WriteLine("Using DataProtectionScope");

            // Create a simple byte array containing data to be encrypted.
            byte[] secret1 = { 0, 1, 2, 3, 4, 1, 2, 3, 4 };

            //Encrypt the data.
            byte[] encryptedSecret1 = Protect(secret1);
            Console.WriteLine("The encrypted byte array is:");
            PrintValues(encryptedSecret1);

            // Decrypt the data and store in a byte array.
            byte[] originalData1 = Unprotect(encryptedSecret1);
            Console.WriteLine("{0}The original data is:", Environment.NewLine);
            PrintValues(originalData1);

            Console.WriteLine("Using MemoryProtectionScope");

            // Create the original data to be encrypted (The data length should be a multiple of 16).
            byte[] secret2 = { 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4, 1, 2, 3, 4 };

            // Encrypt the data in memory. The result is stored in the same same array as the original data.
            ProtectedMemory.Protect(secret2, MemoryProtectionScope.SameLogon);
            Console.WriteLine("The encrypted byte array is:");
            PrintValues(secret2);

            // Decrypt the data in memory and store in the original array.
            ProtectedMemory.Unprotect(secret2, MemoryProtectionScope.SameLogon);
            Console.WriteLine("{0}The original data is:", Environment.NewLine);
            PrintValues(secret2);

            Console.WriteLine();
        }
    }
}