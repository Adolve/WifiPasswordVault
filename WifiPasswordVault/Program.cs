using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace WifiPasswordVault
{
    class Program
    {
        public static void Main()
        {            

            // Generate a 63 char wifi password as the plaintext
            string plainText = Vault.GenerateWifiPassword();
            Console.WriteLine("new generated wifi password: " + plainText);

            // Generate a key from the an old wifi password
            var key = Vault.GeneratePrivateKey("smallpassword");

            // Encrypt the new wifi password with the provided key 
            byte[] ivPlusCipher = Vault.EncryptStringToBytes_AesCBC(plainText, key);

            // Save the ciphertext to file
            // note the file in my case was saved in WifiPasswordVault\bin\Debug\net6.0\
            File.WriteAllBytes("newWifiPassword1.cipher", ivPlusCipher); // Requires System.IO

            // Read the ciphertext from file
            byte[] cipherfromFile= File.ReadAllBytes("newWifiPassword1.cipher");

            // Decrypt the ciphertext to get the wifi password
            string getthewifipassword = Vault.DecryptStringFromBytes_AesCBC(ivPlusCipher, key);

            // print the decrypted wifi password to make sure it matches the original
            Console.WriteLine("wifi password after decryption: "+getthewifipassword);      
                       

        }


    }
}
   

