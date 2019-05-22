using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GenerateNumbers.ExtendedEuclid
{
   public class EuclidExtended
    {
        private BigInteger a, b;

        public EuclidExtended(BigInteger a, BigInteger b)
        {
            this.a = a;
            this.b = b;
        }

        public EuclidExtendedSolution calculate()
        {
            BigInteger x0 = 1, xn = 1;
            BigInteger y0 = 0, yn = 0;
            BigInteger x1 = 0;
            BigInteger y1 = 1;
            BigInteger q;
            BigInteger r = a % b;

            while (r > 0)
            {
                q = a / b;
                xn = x0 - q * x1;
                yn = y0 - q * y1;

                x0 = x1;
                y0 = y1;
                x1 = xn;
                y1 = yn;
                a = b;
                b = r;
                r = a % b;
            }

            return new EuclidExtendedSolution(xn, yn, b);
        }
    }
}
