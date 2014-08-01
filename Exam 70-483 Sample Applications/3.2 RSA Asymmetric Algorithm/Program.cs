using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Security.Cryptography;

namespace _3._2_RSA_Asymmetric_Algorithm
{
    class Program
    {
        static void Main(string[] args)
        {
            string KeyContainerName = "MyKeyContainer";
            string clearText = "This is the data we want to encrypt!";
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = KeyContainerName;

            RSAParameters publicKey;
            RSAParameters privateKey;

            using(var rsa = new RSACryptoServiceProvider(cspParams))
            {
                rsa.PersistKeyInCsp = true;
                publicKey = rsa.ExportParameters(false);
                privateKey = rsa.ExportParameters(true);

                rsa.Clear();
            }

            byte[] encrypted = EncryptUsingRSAParam(clearText, publicKey);
            string decrypted = DecryptUsingRSAParam(encrypted, privateKey);

            Console.WriteLine("Asymmetric RSA - Using RSA Params");
            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);

            Console.WriteLine("Asymmetric RSA - Using Persistent Key Container");
            encrypted = EncryptUsingContainer(clearText, KeyContainerName);
            decrypted = DecryptUsingContainer(encrypted, KeyContainerName);

            Console.WriteLine("Encrypted:{0}", Convert.ToBase64String(encrypted));
            Console.WriteLine("Decrypted:{0}", decrypted);

            Console.ReadLine();
        }

        static byte[] EncryptUsingRSAParam(string value, RSAParameters rsaKeyInfo)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaKeyInfo);
                byte[] encodedData = Encoding.Default.GetBytes(value);
                byte[] encryptedData = rsa.Encrypt(encodedData, true);

                rsa.Clear();
                return encryptedData;
            }
        }

        static string DecryptUsingRSAParam(byte[] encryptedData, RSAParameters rsaKeyInfo)
        {
            using(RSACryptoServiceProvider rsa = new RSACryptoServiceProvider())
            {
                rsa.ImportParameters(rsaKeyInfo);
                byte[] decryptedData = rsa.Decrypt(encryptedData, true);
                string decryptedValue = Encoding.Default.GetString(decryptedData);

                rsa.Clear();
                return decryptedValue;
            }
        }

        static byte[] EncryptUsingContainer(string value, string containerName)
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = containerName;
            using(var rsa = new RSACryptoServiceProvider(cspParams))
            {
                byte[] encodedData = System.Text.Encoding.Default.GetBytes(value);
                byte[] encryptedData = rsa.Encrypt(encodedData, true);

                rsa.Clear();
                return encryptedData;
            }
        }

        static string DecryptUsingContainer(byte[] encryptedData, string containerName)
        {
            CspParameters cspParams = new CspParameters();
            cspParams.KeyContainerName = containerName;
            using(var rsa = new RSACryptoServiceProvider(cspParams))
            {
                byte[] decryptedData = rsa.Decrypt(encryptedData, true);
                string decryptedValue = Encoding.Default.GetString(decryptedData);

                rsa.Clear();
                return decryptedValue;
            }
        }
    }
}
