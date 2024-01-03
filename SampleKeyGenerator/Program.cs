using System;
using AppSoftware.LicenceEngine.Common;
using AppSoftware.LicenceEngine.KeyGenerator;

namespace SampleKeyGenerator
{
    class Program
    {
        static void Main(string[] args)
        {
            while (true)
            {
                // Here in SampleKeyGenerator is the full set of KeyByteSet used to generate the licence key.
                // You should change these values in your solution.
                Console.WriteLine("\nEnter date here, format "+"DD-MM-YYYY");

                Console.WriteLine();
                
                // Console.WriteLine("\nRead data "+ Console.ReadLine());

                // string[] authorsList = Console.ReadLine().Split('/');
                // foreach (string author in authorsList)
                // Console.WriteLine(author);

                string str = Console.ReadLine();// macAddr;
                KeyByteSet[] keyByteSets1 = new KeyByteSet[str.Length];
                // Creating byte array of string length 
                byte[] byt = new byte[str.Length];

                // converting each character into byte 
                // and store it
                for (int i = 0; i < str.Length; i++)
                {
                    byt[i] = Convert.ToByte(str[i]);
                }


                var keyByteSets = new[]
                {
                    /*new KeyByteSet(keyByteNumber: 1, keyByteA: 58, keyByteB: 6, keyByteC: 97),
                    new KeyByteSet(keyByteNumber: 2, keyByteA: 96, keyByteB: 254, keyByteC: 23),
                    new KeyByteSet(keyByteNumber: 3, keyByteA: 11, keyByteB: 185, keyByteC: 69),
                    new KeyByteSet(keyByteNumber: 4, keyByteA: 2, keyByteB: 93, keyByteC: 41),
                    new KeyByteSet(keyByteNumber: 5, keyByteA: 62, keyByteB: 4, keyByteC: 234),
                    new KeyByteSet(keyByteNumber: 6, keyByteA: 200, keyByteB: 56, keyByteC: 49),
                    new KeyByteSet(keyByteNumber: 7, keyByteA: 89, keyByteB: 45, keyByteC: 142),
                    new KeyByteSet(keyByteNumber: 8, keyByteA: 6, keyByteB: 88, keyByteC: 32)*/


                   new KeyByteSet(keyByteNumber: 1, keyByteA: byt[0], keyByteB: byt[0], keyByteC: byt[0]),
                   new KeyByteSet(keyByteNumber: 2, keyByteA: byt[1], keyByteB: byt[1], keyByteC: byt[1]),
                   new KeyByteSet(keyByteNumber: 3, keyByteA: byt[2], keyByteB: byt[2], keyByteC: byt[2]),
                   new KeyByteSet(keyByteNumber: 4, keyByteA: byt[3], keyByteB: byt[3], keyByteC: byt[3]),
                   new KeyByteSet(keyByteNumber: 5, keyByteA: byt[4], keyByteB: byt[4], keyByteC: byt[4]),
                   new KeyByteSet(keyByteNumber: 6, keyByteA: byt[5], keyByteB: byt[5], keyByteC: byt[5]),
                   new KeyByteSet(keyByteNumber: 7, keyByteA: byt[6], keyByteB: byt[6], keyByteC: byt[6]),
                   new KeyByteSet(keyByteNumber: 8, keyByteA: byt[7], keyByteB: byt[7], keyByteC: byt[7])
                };



                // A unique key will be created for the seed value. This value could be a user ID or something
                // else depending on your application logic.

                int seed = new Random().Next(0, int.MaxValue);

                Console.WriteLine("Seed (for example user ID) is:");
                Console.WriteLine(seed);

                // Generate the key ... 

                var pkvLicenceKeyGenerator = new PkvKeyGenerator();

                string licenceKey = pkvLicenceKeyGenerator.MakeKey(seed, keyByteSets);

                Console.WriteLine("Generated licence key is:");
                Console.WriteLine(licenceKey);

                // The values output can now be copied into the SampleKeyVerification console app to demonstrate
                // verification.

                Console.WriteLine("\nCopy these values to a running instance of SampleKeyVerification to test key verification.");

                Console.WriteLine("\nPress any key to generate another licence key.");

                Console.ReadKey();
            }
        }
    }
}
