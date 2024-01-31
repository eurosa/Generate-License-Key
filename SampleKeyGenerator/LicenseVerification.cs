using AppSoftware.LicenceEngine.Common;
using AppSoftware.LicenceEngine.KeyVerification;
using Microsoft.Win32;
using System;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;

namespace SampleKeyGenerator
{
    public static class LicenseVerification
    {
        private static string IsExpired;

        public static string[] LicenseVerify()
        {
            string[] strArray = new string[2];

            /* int day = 0;
             int month = 0;
             int year = 0;
             // string authors = "Mahesh Chand, Henry He, Chris Love, Raj Beniwal, Praveen Kumar";
             // Split authors separated by a comma followed by space
             string[] authorsList = date_.Split('-');
             foreach(string author in authorsList)
             {
                 day  = Int32.Parse(author);
                 month = Int32.Parse(author);
                 year = Int32.Parse(author);
                 Console.WriteLine(author);

             }*/
            string productKey = "G7tpNaaTs1We8KpTD/JG+U0iAE2g04c2po6wAJ6TZ38MOy7IUNwMwZn9Kn7O2DIp"; //"a5jSSQB9UpVQqsfugA3i0mqm4SzejtjBVaYcA5v3bFjlKK1AYTeXWRQ2A9Ex6dwu";

            var secretKey = "b14ca5898a4e4133bbce2ea2315a1916";

            // Console.WriteLine("Please enter a secret key for the symmetric algorithm.");
            // var key = Console.ReadLine();

            // Console.WriteLine("Please enter a string for encryption");
            // var str1 = Console.ReadLine();
            // var encryptedString = AesOperation.EncryptString(key, productKey);
            // Console.WriteLine($"encrypted string = {encryptedString}");

            var decryptedString = AesOperation.DecryptString(secretKey, productKey);

            string[] authorsList = decryptedString.Split('#');

          //  Console.WriteLine($"decrypted string = {decryptedString}");


            // KeyByteSet[] keyByteSets = new KeyByteSet[] { };

            int nProcessID = Process.GetCurrentProcess().Id;

            var macAddr = (from nic in NetworkInterface.GetAllNetworkInterfaces()
                           where nic.OperationalStatus == OperationalStatus.Up
                           select nic.GetPhysicalAddress().ToString()).FirstOrDefault();

            byte[] bytes = Encoding.ASCII.GetBytes(authorsList[1]);

            byte[] bytesData = new byte[100];

            //   Console.WriteLine("cpu Id: " + ByteArrayToString(bytes) + " Machine:" + macAddr);
            //   Console.WriteLine("cpu Id: " + nProcessID + " Machine:" + macAddr);

            string str = authorsList[1];
            KeyByteSet[] keyByteSets1 = new KeyByteSet[authorsList[1].Length];
            // Creating byte array of string length 
            byte[] byt = new byte[str.Length];

            // converting each character into byte 
            // and store it
            for (int i = 0; i < str.Length; i++)
            {
                byt[i] = Convert.ToByte(str[i]);
            }

            // printing characters with byte values
            for (int i = 0; i < byt.Length; i++)
            {
                // Debug.WriteLine("Byte of char \'" + str[i] + "\' : " + byt[i]);
            }

            //  while (true)
            //  {
            // In your application that is to be distributed to the end user (which needs to verify the licence
            // key), only include a subset of the full keyByteSets array used in SampleKeyGenerator. This is so
            // the full set of KeyByteSets is not being compiled into your distributable application code and you have the option
            // of changing the KeyByteSets that are verified.

            /*
            string[] array = new string[2]; // creates array of length 2, default values
            string[] array = new string[] { "A", "B" }; // creates populated array of length 2
            string[] array = { "A" , "B" }; // creates populated array of length 2
            string[] array = new[] { "A", "B" }; // created populated array of length 2
            */



            var keyByteSets = new[]
            {
                      new KeyByteSet(keyByteNumber: 1, keyByteA: byt[0], keyByteB: byt[0], keyByteC: byt[0]),
                      new KeyByteSet(keyByteNumber: 2, keyByteA: byt[1], keyByteB: byt[1], keyByteC: byt[1]),
                      new KeyByteSet(keyByteNumber: 3, keyByteA: byt[2], keyByteB: byt[2], keyByteC: byt[2]),
                      new KeyByteSet(keyByteNumber: 4, keyByteA: byt[3], keyByteB: byt[3], keyByteC: byt[3]),
                      new KeyByteSet(keyByteNumber: 5, keyByteA: byt[4], keyByteB: byt[4], keyByteC: byt[4]),
                      new KeyByteSet(keyByteNumber: 6, keyByteA: byt[5], keyByteB: byt[5], keyByteC: byt[5]),
                      new KeyByteSet(keyByteNumber: 7, keyByteA: byt[6], keyByteB: byt[6], keyByteC: byt[6]),
                      new KeyByteSet(keyByteNumber: 8, keyByteA: byt[7], keyByteB: byt[7], keyByteC: byt[7])

                      /*
                      new KeyByteSet(keyByteNumber: 1, keyByteA: 58, keyByteB: 6, keyByteC: 97),
                      new KeyByteSet(keyByteNumber: 5, keyByteA: 62, keyByteB: 4, keyByteC: 234),
                      new KeyByteSet(keyByteNumber: 8, keyByteA: 6, keyByteB: 88, keyByteC: 32) 
                      */
            };




            // Enter the key generated in the SampleKeyGenerator console app

            //  Console.WriteLine("Enter the key generated from the running instance of SampleKeyGenerator:");

            string key = authorsList[0];// Console.ReadLine();


            var pkvKeyVerifier = new PkvKeyVerifier();

            var pkvKeyVerificationResult = pkvKeyVerifier.VerifyKey(

                key: key?.Trim(),
                keyByteSetsToVerify: keyByteSets,

                // The TOTAL number of KeyByteSets used to generate the licence key in SampleKeyGenerator

                totalKeyByteSets: 8,

                // Add blacklisted seeds here if required (these could be user IDs for example)

                blackListedSeeds: null
            );

            // If the key has been correctly copied, then the key should be reported as valid.

            //   Debug.WriteLine($"Verification result: {pkvKeyVerificationResult}");

            // Debug.WriteLine("\nPress any key to verify another licence key.");

            //  Console.ReadKey();
            //  }

            DateTime d1 = DateTime.Now;
            // DateTime d2 = DateTime.Now.AddDays(-1);
            DateTime myDate = DateTime.Parse(authorsList[1]);
            TimeSpan t = myDate - d1;
            double NrOfDays = t.TotalDays;

            // MessageBox.Show("No of days: "+NrOfDays);
           // Globals.numOfDays = Math.Round(NrOfDays).ToString();
            double period = t.TotalDays;// 21; // trial period
            string keyName = authorsList[0];
            long ticks = DateTime.Today.Ticks;

            RegistryKey rootKey = Registry.CurrentUser;
            RegistryKey regKey = rootKey.OpenSubKey(keyName);
           // if (regKey == null) // first time app has been used
           // {
                regKey = rootKey.CreateSubKey(keyName);
                long expiry = DateTime.Today.AddDays(period).Ticks;
                regKey.SetValue("expiry", expiry, RegistryValueKind.QWord);
               // regKey.Close();
            // }
            //  else
            //  {
                expiry = (long)regKey.GetValue("expiry");
             // long expiry = (long)regKey.GetValue("expiry");
                regKey.Close();
                long today = DateTime.Today.Ticks;


                if (today > expiry)
                {
                  //  Console.WriteLine("Sorry your Software Expired...!!!");
                    IsExpired = "1";

                }
                else
                {

                  //  Console.WriteLine("Sorry your Software not Expired...!!!" + expiry);
                    IsExpired = "0";
                    
                }

            // }

            strArray[0] = pkvKeyVerificationResult.ToString();
            strArray[1] = IsExpired;


            pkvKeyVerifier = null;
            return strArray;
        }

        public static string ByteArrayToString(byte[] ba)
        {
            StringBuilder hex = new StringBuilder(ba.Length * 2);
            foreach (byte b in ba)
                hex.AppendFormat("{0:x2}", b);
            return hex.ToString();
        }
    }
}
