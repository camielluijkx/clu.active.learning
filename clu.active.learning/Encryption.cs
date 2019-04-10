using System;
using System.Security.Cryptography;
using System.Text;

namespace clu.active.learning
{
    /*
    
    It is a common requirement for applications to be able to secure information, whether it is a case of encrypting files saved to disk or web 
    requests sent over an untrusted connection to other remote systems. The Microsoft® .NET Framework provides a variety of classes that enable 
    you to secure your data by using encryption and hashing. 

    */
    public static class Encryption
    {
        #region Public Methods

        /*
        
        Symmetric encryption is the process of performing a cryptographic transformation of data by using a mathematical algorithm. Symmetric 
        encryption is an established technique and is used by many applications to provide a robust way of protecting confidential data. 

        The name symmetric is derived from the fact that the same secret key is used to encrypt and decrypt the data. Therefore, when you use 
        symmetric encryption, you must keep the secret key secure. 

        To help improve the effectiveness of symmetric encryption, many symmetric encryption algorithms also use an initialization vector (IV) 
        in addition to a secret key. The IV is an arbitrary block of bytes that helps to randomize the first encrypted block of data. The IV 
        makes it much more difficult for a malicious user to decrypt your data. 

        */
        public static void ImplementingSymmetricEncryption()
        {
            Console.WriteLine("* Implementing Symmetric Encryption");
            {
                /*
                
                The following table describes some of the advantages and disadvantages of symmetric encryption. 

                Advantage                                                   Disadvantage 
                There is no limit on the amount of data you can encrypt.    The same key is used to encrypt and decrypt the data. If the key is 
                                                                            compromised, anyone can encrypt and decrypt the data. 
                Symmetric algorithms are fast and consume far fewer system  If you choose to use a different secret key for different data, you
                resources than asymmetric algorithms.                       could end up with many different secret keys that you need to manage. 

                Symmetric algorithms are perfect for quickly encrypting large amounts of data.

                */
                Console.WriteLine("** Advantages and Disadvantages of Symmetric Encryption");
                {

                }

                /*
                
                The .NET Framework contains a number of classes in the System.Security.Cryptography namespace, which provide managed implementations 
                of common symmetric encryption algorithms, such as Advanced Encryption Standard (AES), Data Encryption Standard (DES), and TripleDES. 
                Each .NET Framework symmetric encryption class is derived from the abstract SymmetricAlgorithm base class. 

                The following table describes the key characteristics of the.NET Framework encryption classes. 

                Algorithm               .NET Framework Class            Encryption Technique                    Block Size              Key Size 
                DES                     DESCryptoServiceProvider        Bit shifting and bit substitution       64 bits                 64 bits
                AES                     AesManaged                      Substitution-Permutation Network (SPN)  128 bits                128, 192, or 256 
                                                                                                                                        bits
                Rivest Cipher 2 (RC2)   RC2CryptoServiceProvider        Feistel network                         64 bit                  40-128 bits 
                                                                                                                                        (increments of 8 
                                                                                                                                        bits)
                Rijndael                RijndaelManaged                 SPN                                     128-256 bits            128, 192, or 256 
                                                                                                                (increments of 32       bits
                                                                                                                bits) 
                TripleDES               TripleDESCryptoServiceProvider Bit shifting and bit substitution        64 bit                  128-192 bits

                Each of the .NET Framework encryption classes are known as block ciphers, which means that the algorithm will chunk data into 
                fixed-length blocks and then perform a cryptographic transformation on each block. 

                You can measure the strength of an encryption algorithm by the key size. The higher the number of bits, the more difficult it is for 
                a malicious user trying a large number of possible secret keys to decrypt your data. 

                https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.symmetricalgorithm?view=netframework-4.7.2

                */
                Console.WriteLine("** Symmetric Encryption Classes in the .NET Framework");
                {

                }

                /*
                 
                You can encrypt data by using any of the symmetric encryption classes in the System.Security.Cryptography namespace. However, these 
                classes only provide managed implementations of a particular encryption algorithm; for example, the AesManaged class provides a 
                managed implementation of the AES algorithm. Aside from encrypting and decrypting data by using an algorithm, the encryption process 
                typically involves the following tasks: 

                    • Derive a secret key and an IV from a password or salt. A salt is a random collection of bits used in combination with a password 
                      to generate a secret key and an IV. A salt makes it much more difficult for a malicious user to randomly discover the secret key. 
                    • Read and write encrypted data to and from a stream.

                To help simplify the encryption logic in your applications, the .NET Framework includes a number of other cryptography classes that 
                you can use. 
                
                The Rfc2898DeriveBytes class provides an implementation of the password-based key derivation function (PBKDF2), which complies with 
                the Public-Key Cryptography Standards (PKCS). You can use the PBKDF2 functionality to derive your secret keys and your IVs from a 
                password and a salt. 

                https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rfc2898derivebytes?view=netframework-4.7.2

                The CryptoStream class is derived from the abstract Stream base class in the System.IO namespace, and it provides streaming 
                functionality specific to reading and writing cryptographic transformations. 

                https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.cryptostream?view=netframework-4.7.2

                */
                Console.WriteLine("** Encrypting Data by Using Symmetric Encryption");
                {

                }

                /*
                
                The following steps describe how to encrypt and decrypt data by using the AesManaged class: 

                    1. Create an Rfc2898DeriveBytes object, which you will use to derive the secret key and the IV.
                    2. Create an instance of the encryption class that you want to use to encrypt the data.
                 
                */
                Console.WriteLine("** Symmetrically Encrypting and Decrypting Data");
                {
                    var password = "Pa$$w0rd";
                    var salt = "S@lt";
                    var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

                    var algorithm = new AesManaged();


                }
            }
        }

        #endregion
    }
}
