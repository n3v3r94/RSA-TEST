using System;
using System.Collections.Generic;
using System.Numerics;
using System.Text;

namespace GenerateNumbers.ExtendedEuclid
{
   public class EuclidExtendedSolution
    {
        private BigInteger x, y, d;

        public BigInteger X
        {
            get
            {
                return this.x;
            }
        }

        public BigInteger Y
        {
            get
            {
                return this.y;
            }
        }

        public BigInteger D
        {
            get
            {
                return this.d;
            }
        }

        public EuclidExtendedSolution(BigInteger x, BigInteger y, BigInteger d)
        {
            this.x = x;
            this.y = y;
            this.d = d;
        }
    }
}
