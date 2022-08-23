using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Security.Cryptography;

namespace ATG.Utilities.Crypto {

    public class AES {
        private static byte[] _key = System.Text.Encoding.UTF8.GetBytes("kelske243AKEQkeemwke2jk3yKD3jh2H");
        private static byte[] _iv = System.Text.Encoding.UTF8.GetBytes("O39l49sdks3)pP23");

        /// <summary>
        /// Encrypt a plain-text string using AES
        /// </summary>
        /// <param name="plainText">The plain-text string to encrypt</param>
        /// <returns>An encrypted byte array</returns>
        public static byte[] EncryptStringToBytes(string plainText) {
            byte[] encrypted = null;

            if ((null != plainText)
                && (plainText.Length > 0)
            ) {
                // Create an AesCryptoServiceProvider object 
                // with the specified key and IV. 
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider()) {
                    aesAlg.Key = _key;
                    aesAlg.IV = _iv;

                    // Create a encryptor to perform the stream transform.
                    ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for encryption. 
                    using (MemoryStream msEncrypt = new MemoryStream()) {
                        using (System.Security.Cryptography.CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write)) {
                            using (StreamWriter swEncrypt = new StreamWriter(csEncrypt)) {
                                //Write all data to the stream.
                                swEncrypt.Write(plainText);
                            }
                            encrypted = msEncrypt.ToArray();
                        }
                    }
                }
            }
            return encrypted;
        }

        /// <summary>
        /// Decrypt a byte-array that was previously encrypted using EncryptStringToBytes()
        /// </summary>
        /// <param name="cipherText">The encrypted string to decrypt</param>
        /// <returns>The plain-text string</returns>
        public static string DecryptStringFromBytes(byte[] cipherText) {
            string plaintext = null;

            if ((null != cipherText)
                && (cipherText.Length > 0)
            ) {
                // Create an AesCryptoServiceProvider object 
                // with the specified key and IV. 
                using (AesCryptoServiceProvider aesAlg = new AesCryptoServiceProvider()) {
                    aesAlg.Key = _key;
                    aesAlg.IV = _iv;

                    // Create a decrytor to perform the stream transform.
                    ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                    // Create the streams used for decryption. 
                    using (MemoryStream msDecrypt = new MemoryStream(cipherText)) {
                        using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read)) {
                            using (StreamReader srDecrypt = new StreamReader(csDecrypt)) {
                                // Read the decrypted bytes from the decrypting stream 
                                // and place them in a string.
                                plaintext = srDecrypt.ReadToEnd();
                            }
                        }
                    }
                }
            }
            return plaintext;
        }

        /// <summary>
        /// Determine if the plain-text string is equal to the encrypted byte-array. Comparison
        /// is done by encrypting the string and comparing all bytes in both byte-arrays for equality.
        /// </summary>
        /// <param name="plainText">The plain text string for comparison</param>
        /// <param name="cipherText">The byte-array for comparison</param>
        /// <returns>Returns true if the encryption of the string results in a byte-array
        /// that is equivalent to the cipherText byte-array. Otherise, false is returned.</returns>
        public static bool Equals(string plainText, byte[] cipherText) {
            // encrypte string
            byte[] encryptedText = EncryptStringToBytes(plainText);

            // byte-for-byte comparision between encrypted string and the ciptherText.
            return ((null != encryptedText)
                    && (null != cipherText)
                    && (encryptedText.Length == cipherText.Length)
                    && (!cipherText.Where((t, i) => t != encryptedText[i]).Any()));
        }
    }
}
