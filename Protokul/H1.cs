using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Protokul
{
    class H1
    {
        int value1;
        int value2;

        public H1(int value1, int value2)
        {
            this.value1 = value1;
            this.value2 = value2;
        }


        public int GetHashCode(int group)
        {
            
            SHA256 mySHA256 = SHA256.Create();
            byte[] bytes = BitConverter.GetBytes(value1);
            byte[] result = mySHA256.ComputeHash(bytes);

            BigInteger hashValue1 = new BigInteger(mySHA256.ComputeHash(BitConverter.GetBytes(value1)));
            BigInteger hashValue2 = new BigInteger(mySHA256.ComputeHash(BitConverter.GetBytes(value2)));

            BigInteger hashCode = new BigInteger(group);
            BigInteger primeNumber = new BigInteger(group);
            hashCode = hashCode * primeNumber + hashValue1;
            hashCode = hashCode * primeNumber + hashValue2;

            BigInteger bigGroup = new BigInteger(group);
            hashCode = hashCode % bigGroup;

          

            return Math.Abs((int)hashCode);
        }

        
    }
}
