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
            Console.OutputEncoding = Encoding.UTF8;
            Random rnd = new Random();
            for (int k  = 0; k < 1; k++)
            {
                Console.WriteLine("Please enter length of prime number 3 - 12");
                int lenght =  int.Parse(Console.ReadLine()); /*rnd.Next(3, 13);*/

                BigInteger p1 = GeneratePrimeNumber(lenght);
                BigInteger p2 = GeneratePrimeNumber(lenght);

                Console.WriteLine($"p1= {p1.ToString().Length} {Environment.NewLine} p2= {p2.ToString().Length}");

                BigInteger n = BigInteger.Multiply(p1, p2);
                BigInteger phiN = BigInteger.Multiply((p1 - 1), (p2 - 1));
                Console.WriteLine($"Phi: {phiN} -> length {phiN.ToString().Length}");


                BigInteger e = GeneratePublicExponentE(lenght, phiN);
                Console.WriteLine($"e= {e}");


                EuclidExtended ee = new EuclidExtended(e, phiN);
                EuclidExtendedSolution result = ee.calculate();

                BigInteger d = result.X < 0 ? BigInteger.Subtract(phiN, BigInteger.Abs(result.X)) : result.X;



                Console.WriteLine($"d={d}");
                if (e > n)
                {
                    Console.WriteLine("Sorry try again. n must must be biggest from e"); 
                }

                string messages = Console.ReadLine(); /*"CRYPTED";*/

                byte[] messagesInBytes = Encoding.UTF8.GetBytes(messages);

                BigInteger[] cryptedMessages = new BigInteger[messages.Length];


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

                    Console.Write($"{(char)(encryptedMessages[i])}");
                }

                Console.WriteLine();
            }

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

            return num1;
        }

        public static BigInteger GeneratePrimeNumber(int length)
        {
            Random rnd = new Random();
            BigInteger p = BigInteger.Parse(StartNumber(length));
            string lenghtNumbers = StartNumberMax(length);
            BigInteger test = BigInteger.Parse(lenghtNumbers);

            for (int i = 2; i < p; i++)
            {
               
                if (test> int.MaxValue)
                {
                    p += rnd.Next(1, int.MaxValue);
                }

                if (test<int.MaxValue)
                {
                    p += rnd.Next(1, int.Parse(StartNumberMax(length)));
                }

                if (IsPrime(p))
                {
                    break;
                }
            }
          

            return p;
        }


        public static BigInteger GeneratePublicExponentE(int length, BigInteger PhiN)
        {
            BigInteger e = BigInteger.Parse(StartNumber(length));
            Random rnd = new Random();
            string lenghtNumbers = StartNumberMax(length);
            BigInteger test = BigInteger.Parse(lenghtNumbers);
            for (BigInteger i = e; i < PhiN; i++)
            {

                if (test > int.MaxValue)
                {
                    i += rnd.Next(1, int.MaxValue);
                }

                if (test < int.MaxValue)
                {
                    i += rnd.Next(1, int.Parse(StartNumberMax(length)));
                }

                //i += rnd.Next(1, 1000);

                if (!(i.IsEven) && (GCD(i, PhiN) == 1))
                {
                    e = i;
                    break;
                }
            }

            return e;
        }


        public static string StartNumber(int lenght)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lenght; i++)
            {
                if (i == 0)
                {
                    sb.Append("1");
                }
                else
                {
                    sb.Append("0");
                }

            }

            return sb.ToString();
        }

        public static string StartNumberMax(int lenght)
        {
            StringBuilder sb = new StringBuilder();
            for (int i = 0; i < lenght; i++)
            {
                sb.Append("9");

            }

            return sb.ToString();
        }

        public static bool IsPrime(BigInteger candidate)
        {
           
            if ((candidate & 1) == 0)
            {
                if (candidate == 2)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
           
            for (BigInteger i = 3; (i * i) <= candidate; i += 2)
            {
                if ((candidate % i) == 0)
                {
                    return false;
                }
            }
            return candidate != 1;
        }

    }
}
