using System;
using System.Numerics;
using System.Text;

namespace RSATestWithSmallNumber
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = System.Text.Encoding.UTF8;
            Random rnd = new Random();
            BigInteger seed = new BigInteger(2432443243434343689);

            //alice
            //BigInteger p1 = new BigInteger();

            BigInteger p1 = new BigInteger( 103177);
            BigInteger p2 = new BigInteger(103183);


            //for (int i = 0; i < 20; i++)
            //{
                //p1  = rnd.Next(100000, int.MaxValue);
                //if (i > 10 && p1.IsEven)
                //{
                    //break;
                //}
            //}

            //var temp = p1;
            //for (int i = 0; i < 100000; i++)
            //{
                //++temp;
                //if (temp.IsEven)
                //{
                    //p2 = temp;
                    //break;
                //}

            //}



            Console.WriteLine($"p1= {p1.ToString().Length} {Environment.NewLine} p2= {p2.ToString().Length}");


            BigInteger n = p1 * p2;
            BigInteger phiN = (p1 - 1) * (p2 - 1);
            Console.WriteLine($"Phi: {phiN.ToString().Length}");
            int e = 3;
            BigInteger d = 2 * (phiN + 1) / e;
            //Console.WriteLine($"d: {d}");
            //bob


            string messages = "SECRET";

            byte[] messagesInBytes = Encoding.UTF8.GetBytes(messages);

            BigInteger[] cryptedMessages = new BigInteger[messages.Length];

            for (int i = 0; i < messagesInBytes.Length; i++)
            {
                cryptedMessages[i] = BigInteger.ModPow(messagesInBytes[i], e, n);
            }


            BigInteger[] encryptedMessages = new BigInteger[messages.Length];
            for (int i = 0; i < cryptedMessages.Length; i++)
            {
                encryptedMessages[i] = BigInteger.ModPow(cryptedMessages[i], d, n);
                Console.WriteLine((char)encryptedMessages[i]);
            }

            Console.ReadKey();
        }



    }
}
