using System;
using System.IO;
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
        #region Implementation

        private static void dumpBytes(string title, byte[] bytes)
        {
            Console.Write(title);
            foreach (var b in bytes)
            {
                Console.Write($"{b:X} ");
            }
            Console.WriteLine();
        }

        private static byte[] computeHash(byte[] dataToHash, byte[] secretKey)
        {
            using (var hashAlgorithm = new HMACSHA1(secretKey))
            {
                using (var bufferStream = new MemoryStream(dataToHash))
                {
                    return hashAlgorithm.ComputeHash(bufferStream);
                }
            }
        }

        #endregion


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
        public static void UsingSymmetricEncryption()
        {
            Console.WriteLine("* Using Symmetric Encryption");
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
                    3. Generate the secret key and the IV from the Rfc2898DeriveBytes object.
                    4. Create a stream object that you will use to buffer the encrypted or unencrypted bytes.
                    5. Create either a symmetric encryptor or decryptor depending on whether you want to encrypt or decrypt data.
                    6. Create a CryptoStream object, which you will use to write the cryptographic bytes to the buffer stream.
                    7. Invoke the Write and FlushFinalBlock methods on the CryptoStream object, to perform the cryptographic transform.
                    8. Invoke the Close method on the CryptoStream and the MemoryStream objects, so that the transformed data is flushed to the 
                       buffer stream.

                You typically use the algorithm’s KeySize and BlockSize properties when generating the secret key and the IV, so that the secret 
                key and the IV that you generate are compatible with the algorithm. 

                rgb random generated bytes

                */
                Console.WriteLine("** Symmetrically Encrypting and Decrypting Data");
                {
                    var converter = new ASCIIEncoding();
                    var messageToEncrypt = "my super secret data";
                    Console.WriteLine($"Message to encrypt: {messageToEncrypt}");

                    var password = "Pa$$w0rd";
                    var salt = "S@lt";
                    var rgb = new Rfc2898DeriveBytes(password, Encoding.Unicode.GetBytes(salt));

                    var algorithm = new AesManaged();

                    var rgbKey = rgb.GetBytes(algorithm.KeySize / 8);
                    dumpBytes("Key: ", rgbKey);
                    var rgbIV = rgb.GetBytes(algorithm.BlockSize / 8);
                    dumpBytes("IV: ", rgbIV);

                    var encryptor = algorithm.CreateEncryptor(rgbKey, rgbIV);

                    var encryptBufferStream = new MemoryStream();
                    var encryptCryptoStream = new CryptoStream(encryptBufferStream, encryptor, CryptoStreamMode.Write);

                    var bytesToEncrypt = converter.GetBytes(messageToEncrypt);
                    encryptCryptoStream.Write(bytesToEncrypt, 0, bytesToEncrypt.Length);
                    encryptCryptoStream.FlushFinalBlock();

                    var encryptedBytes = encryptBufferStream.ToArray();
                    dumpBytes("Encrypted bytes: ", encryptedBytes);

                    encryptCryptoStream.Close();
                    encryptBufferStream.Close();

                    var decryptor = algorithm.CreateDecryptor(rgbKey, rgbIV);

                    var decryptBufferStream = new MemoryStream(encryptedBytes);
                    var decryptCryptoStream = new CryptoStream(decryptBufferStream, decryptor, CryptoStreamMode.Read);

                    var decryptStreamReader = new StreamReader(decryptCryptoStream);
                    var decryptedText = decryptStreamReader.ReadToEnd();
                    Console.WriteLine($"Decrypted text: {decryptedText}");

                    decryptCryptoStream.Close();
                    decryptBufferStream.Close();
                }
            }
        }

        public static void HashingData()
        {
            /*
            
            Hashing is the process of generating a numerical representation of your data. Typically, hash algorithms compute hashes by mapping the 
            binary representation of your data to the binary values of a fixed-length hash. If you use a proven hash algorithm, it is considered 
            unlikely that you could compute the same hash from two different pieces of data. Therefore, hashes are considered a reliable way to 
            generate a unique digital fingerprint that can help to ensure the integrity of data. 
            
            Consider the example of the FourthCoffee.Beverage service, which sends messages to the FourthCoffee.Inventory service. When the 
            FourthCoffee.Inventory service receives a message, how do the two services know that the message was not sabotaged during the 
            transmission? You could use hashes, as the following steps describe: 

                1. Compute a hash of the message before the FourthCoffee.Beverage service sends the message.
                2. Compute a hash of the message when the FourthCoffee.Inventory service receives the message. 
                3. Compare the two hashes. If the two hashes are identical, the data has not been tampered with. If the data has been modified, the 
                   two hashes will not match. 

            The .NET Framework provides a number of classes in the System.Security.Cryptography namespace, which encapsulate common hash algorithms. 

            Hash Algorithms in the .NET Framework 

            The following table describes some of the hash classes that the .NET Framework provides.

            .NET Framework Class        Description 
            SHA512Managed               The SHA512Managed class is an implementation of the Secure Hash Algorithm (SHA) and is able to compute a 
                                        512-bit hash. The .NET Framework also includes classes that implement the SHA1, SHA256, and SHA384 algorithms. 
            HMACSHA512                  The HMACSHA512 class uses a combination of the SHA512 hash algorithm and the Hash-Based Message Authentication 
                                        Code (HMAC) to compute a 512-bit hash. 
            MACTripleDES                The MACTripleDES class uses a combination of the TripleDES encryption algorithm and a Message Authentication 
                                        Code (MAC) to compute a 64-bit hash. 
            MD5CryptoServiceProvider    The MD5CryptoServiceProvider class is an implementation of the Message Digest (MD) algorithm, which uses block 
                                        chaining to compute a 128-bit hash. 
            RIPEMD160Managed            The RIPEMD160Managed class is derived from the MD algorithm and is able to compute a 160-bit hash. 

            */
            Console.WriteLine("* Hashing Data");
            {
                /*
                
                To compute a hash by using the HMACSHA512 class, perform the following steps: 

                    1. Generate a secret key that the hash algorithm will use to hash the data. The sender would need access to the key to generate 
                       the hash, and the receiver would need access to the key to verify the hash. 
                    2. Create an instance of the hash algorithm.
                    3. Invoke the ComputeHash method, passing in a stream that contains the data you want to hash. The ComputeHash method returns a 
                       byte array that represents the hash of your data. 

                https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-services#hash_values

                */
                Console.WriteLine("** Hashing Data by Using the HMACSHA512 class");
                {
                    var converter = new ASCIIEncoding();
                    var messageTohash = "my super secret data";
                    Console.WriteLine($"Message to hash: {messageTohash}");

                    var secretKeyToHash = "Pa$$w0rd";

                    var messageBytesToHash = converter.GetBytes(messageTohash);
                    var secretKeyBytesToHash = converter.GetBytes(secretKeyToHash);

                    var hashedBytes = computeHash(messageBytesToHash, secretKeyBytesToHash);
                    dumpBytes("Hashed bytes: ", hashedBytes);
                }
            }
        }

        public static void UsingAsymmetricEncryption()
        {
            /*
            
            Asymmetric encryption is the process of performing a cryptographic transformation of data by using an asymmetric encryption algorithm 
            and a combination of public and private keys. 

            Unlike symmetric encryption, where one secret key is used to perform both the encryption and the decryption, asymmetric encryption uses 
            a public key to perform the encryption and a private key to perform the decryption. 

            The public and private keys are mathematically linked, in that the private key is used to derive the public key. However, you cannot 
            derive a private key from a public key. Also, you can only decrypt data by using the private key that is linked to the public key that 
            was used to encrypt the data. 

            In a system that uses asymmetric encryption, the public key is made available to any application that requires the ability to encrypt 
            data. However, the private key is kept safe and is only distributed to applications that require the ability to decrypt the data. For 
            example, HTTPS uses asymmetric encryption to encrypt and decrypt the browser’s session key when establishing a secure connection between 
            the browser and the server. 

            You can also use asymmetric algorithms to sign data. Signing is the process of generating a digital signature so that you can ensure the 
            integrity of the data. When signing data, you use the private key to perform the signing and then use the public key to verify the data. 

            https://docs.microsoft.com/en-us/dotnet/standard/security/cryptographic-services#public_key

            */
            Console.WriteLine("* Using Asymetric Encryption");
            {
                /*
                
                The following table describes some of the advantages and disadvantages of asymmetric encryption. 

                Advantage                                                               Disadvantage 
                Asymmetric encryption relies on two keys, so it is easier to            With asymmetric encryption, there is a limit on the amount of 
                distribute the keys and to enforce who can encrypt and decrypt the      data that you can encrypt. The limit is different for each 
                data                                                                    algorithm and is typically proportional with the key size of 
                                                                                        the algorithm. For example, an RSACryptoServiceProvider object 
                                                                                        with a key length of 1,024 bits can only encrypt a message that 
                                                                                        is smaller than 128 bytes.
                       
                Asymmetric algorithms use larger keys than symmetric algorithms, and    Asymmetric algorithms are very slow in comparison to symmetric 
                they are therefore less susceptible to being cracked by using brute     algorithms.
                force attacks. 

                Asymmetric encryption is a powerful encryption technique, but it is not designed for encrypting large amounts of data. If you want to 
                encrypt large amounts of data with asymmetric encryption, you should consider using a combination of asymmetric and symmetric 
                encryption. 

                To encrypt data by using asymmetric and symmetric encryption, perform the following steps: 

                    1. Encrypt the data by using a symmetric algorithm, such as the AesManaged class. 
                    2. Encrypt the symmetric secret key by using an asymmetric algorithm.
                    3. Create a stream and write bytes for the following:
                        • The length of the IV
                        • The length of the encrypted secret key
                        • The IV
                        • The encrypted secret key
                        • The encrypted data

                To decrypt, simply step through the stream extracting the data, decrypt the symmetric encryption key, and then decrypt the data.

                */
                Console.WriteLine("** Advantages and Disadvantages of Asymmetric Encryption");
                {

                }

                /*
                
                The .NET Framework contains a number of classes in the System.Security.Cryptography namespace, which enable you to implement 
                asymmetric encryption and signing. Each .NET Framework asymmetric class is derived from the AsymmetricAlgorithm base class. 

                The following list describes some of these classes:

                • RSACryptoServiceProvider. This class provides an implementation of the RSA algorithm, which is named after its creators, Ron 
                  Rivest, Adi Shamir, and Leonard Adleman. By default, the RSACryptoServiceProvider class supports key lengths ranging from 384 to 
                  512 bits in 8-bit increments, but optionally, if you have the Microsoft Enhanced Cryptographic Provider installed, the 
                  RSACryptoServiceProvider class will support keys up to 16,384 bits in length. You can use the RSACryptoServiceProvider class to 
                  perform both encryption and signing. 
                • DSACryptoServiceProvider. This class provides an implementation of the Digital Signature Algorithm (DSA) algorithm and supports 
                  keys ranging from 512 to 1,024 bits in 64-bit increments. Although the RSACryptoServiceProvider class supports both encryption 
                  and signing, the DSACryptoServiceProvider class only supports signing. 

                */
                Console.WriteLine("** Asymmetric Encryption Classes in the .NET Framework");
                {

                }

                /*
                
                You can encrypt your data asymmetrically by using the RSACryptoServiceProvider class in the System.Security.Cryptography namespace. 

                The RSACryptoServiceProvider class provides a number of members that enable you to implement asymmetric encryption functionality 
                in your applications, including the ability to import and export key information and encrypt and decrypt data. 

                You can create an instance of the RSACryptoServiceProvider class by using the default constructor. If you choose this approach, 
                the RSACryptoServiceProvider class will generate a set of public and private keys. 

                */
                Console.WriteLine("** Instantiating the RSACryptoServiceProvider Class");
                {
                    var rsaProvider = new RSACryptoServiceProvider();
                }

                /*
                
                After you have created an instance of the RSACryptoServiceProvider class, you can then use the Encrypt and Decrypt methods to 
                protect your data. 

                You use the useOaepPadding parameter to determine whether the Encrypt and Decrypt methods use Optimal Asymmetric Encryption 
                Padding (OAEP). If you pass true, the methods use OAEP, and if you pass false, the methods use PKCS#1 v1.5 padding. 

                */
                Console.WriteLine("** Encrypting and Decrypting Data by Using the RSACryptoServiceProvider Class");
                {
                    var plainText = "hello world…";
                    var rawBytes = Encoding.Default.GetBytes(plainText);

                    using (var rsaProvider = new RSACryptoServiceProvider())
                    {
                        var useOaepPadding = true;

                        var encryptedBytes = rsaProvider.Encrypt(rawBytes, useOaepPadding);
                        var decryptedBytes = rsaProvider.Decrypt(encryptedBytes, useOaepPadding);

                        var encryptedText = Encoding.Default.GetString(encryptedBytes);
                        Console.WriteLine($"Encrypted text: {encryptedText}");

                        var decryptedText = Encoding.Default.GetString(decryptedBytes);
                        Console.WriteLine($"Decrypted text: {decryptedText}");
                    }
                    // The decryptedText variable will now contain " hello world…"
                }

                /*
                
                Typically, applications do not encrypt and decrypt data in the scope of the same RSACryptoServiceProvider object. One application 
                may perform the encryption, and then another performs the decryption. If you attempt to use different RSACryptoServiceProvider 
                objects to perform the encryption and decryption, without sharing the keys, the Decrypt method will throw a CryptographicException 
                exception. The RSACryptoServiceProvider class exposes members that enable you to export and import the public and private keys. 

                The exportPrivateKey parameter instructs the ExportCspBlob method to include the private key in the return value. If you pass false
                into the ExportCspBlob method, the return value will not contain the private key. If you try to decrypt data without a private key,
                the Common Language Runtime (CLR) will throw a CryptographicException exception.

                Instead of maintaining and persisting keys in your application, you can use the public and private keys in an X509 certificate, 
                stored in the certificate store on the computer that is running your application. 

                https://docs.microsoft.com/en-us/dotnet/api/system.security.cryptography.rsacryptoserviceprovider?view=netframework-4.7.2

                */
                Console.WriteLine("** Importing and Exporting Keys");
                {
                    var keys = default(byte[]);
                    var exportPrivateKey = true;

                    using (var rsaProvider = new RSACryptoServiceProvider())
                    {
                        keys = rsaProvider.ExportCspBlob(exportPrivateKey);
                        // Code to perform encryption.
                    }

                    using (var rsaProvider = new RSACryptoServiceProvider())
                    {
                        rsaProvider.ImportCspBlob(keys);
                        // Code to perform decryption.
                    }
                }
            }
        }

        public static void CreatingAndManagingCertificates()
        {
            /*
            
            TODO

            */
            Console.WriteLine("* Creating and Managing Certificates");
            {
                // TODO
            }
        }

        #endregion
    }
}
