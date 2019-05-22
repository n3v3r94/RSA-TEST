using GenerateNumbers.ExtendedEuclid;
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




            BigInteger p1 = new BigInteger(885320963);
            BigInteger p2 = new BigInteger(238855417);




            //for (int i = 0; i < 20; i++)
            //{
            //    p1 = rnd.Next(100000, int.MaxValue);
            //    if (i > 10 && p1.IsEven)
            //    {
            //        break;
            //    }
            //}

            //var temp = p1;
            //for (int i = 0; i < 100000; i++)
            //{
            //    ++temp;
            //    if (temp.IsEven)
            //    {
            //        p2 = temp;
            //        break;
            //    }

            //}

            Console.WriteLine($"p1= {p1.ToString().Length} {Environment.NewLine} p2= {p2.ToString().Length}");

            BigInteger n = BigInteger.Multiply( p1 , p2);
            BigInteger phiN = BigInteger.Multiply ((p1 - 1) , (p2 - 1));
            Console.WriteLine($"Phi: {phiN.ToString().Length}");



            int e = rnd.Next(1000, 10000);
            BigInteger d;  /*116402471153538991; 2 * (phiN + 1) / e;*/

            do
            {

                EuclidExtended ee = new EuclidExtended(e, phiN);
                EuclidExtendedSolution result = ee.calculate();

                if (result.X < 0)
                {
                    d = phiN - BigInteger.Abs(result.X);
                }

                if (d * e % phiN == 1)
                {
                    Console.WriteLine("success");
                    break;
                }

                e = rnd.Next(1000, 10000);
            } while (!(d * e % phiN == 1));




            string messages = Console.ReadLine();

            byte[] messagesInBytes = Encoding.UTF8.GetBytes(messages);

            BigInteger[] cryptedMessages = new BigInteger[messages.Length];
            Console.WriteLine($"d= {d}  e= {e}");

            foreach (var item in messagesInBytes)
            {
                if (item > n)
                {
                    Console.WriteLine("Messages is broken. m must be smaller than n ");
                    return;
                }
            }
            Console.Write($"Crypted messages: ");
            for (int i = 0; i < messagesInBytes.Length; i++)
            {
                cryptedMessages[i] = BigInteger.ModPow(messagesInBytes[i], e, n);
               
                    Console.Write($"{(char)((cryptedMessages[i]) % char.MaxValue)} ");
            }




            BigInteger[] encryptedMessages = new BigInteger[messages.Length];
            Console.WriteLine();
            Console.Write($"Encrypted messages: ");
            for (int i = 0; i < cryptedMessages.Length; i++)
            {
                encryptedMessages[i] = BigInteger.ModPow(cryptedMessages[i], d, n);

                Console.Write($"{(char)(encryptedMessages[i] )}");
            }

            Console.WriteLine();


            Console.ReadKey();
        }

        static BigInteger GCD(BigInteger num1, BigInteger num2)
        {
            BigInteger Remainder;

            while (num2 != 0)
            {
                Remainder = num1 % num2;
                num1 = num2;
                num2 = Remainder;
            }
            Console.WriteLine(num1);
            return num1;
        }

        void extended_euclid(int a, int b, int x1, int y1, int d)
        {
            int q, r, x2, y2, t;
            x1 = 1; y1 = 0; x2 = 0; y2 = 1;
            while (b != 0)
            {
                q = a / b;
                r = a % b;
                a = b;
                b = r;

                t = x2; x2 = x1 - q * x2; x1 = t;

                t = y2; y2 = y1 - q * y2; y1 = t;
            }
            d = a;
        }

        //Hard code example
        /*
                    BigInteger p3 = 11;
                    BigInteger p4 = 5;
                    BigInteger n2 = p3 * p4;
                    //BigInteger m = 30120;
                    BigInteger e2 = 7;
                    //BigInteger c2 = BigInteger.ModPow(m, e, n);
                    BigInteger phiN2 = (p3 - 1) * (p4 - 1);
                    EuclidExtended ee = new EuclidExtended(e, phiN);
                    EuclidExtendedSolution result = ee.calculate();
                    Console.WriteLine($"D={result.D} x={result.X} y={result.Y}");
                    BigInteger d2 = (phiN2 - (-result.X)) ;

                    //end example
                    */
    }
}
