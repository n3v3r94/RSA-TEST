using System;
using System.Numerics;

namespace GenerateNumbers.Generate
{
    public static class Generator
    {

       
       public static BigInteger GenerateSeed()
        {
            Random rnd = new Random();

            BigInteger seed = new BigInteger(1);

            for (int i = 1; i < 4016; i++)
            {
                seed *= 2;
            }
            return seed;
        }

    }
}
