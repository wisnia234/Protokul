using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Protokul
{
    class H2
    {
        string a;
        string b;

        BigInteger value1;
        BigInteger value2;
        BigInteger value3;

        public H2(string a, string b)
        {
            this.a = a;
            this.b = b;
        }

        public BigInteger Value1
        {
            get
            {
                return value1;
            }
            set
            {
                value1 = value;
            }
        }
        public BigInteger Value2
        {
            get
            {
                return value2;
            }
            set
            {
                value2 = value;
            }
        }
        public BigInteger Value3
        {
            get
            {
                return value3;
            }
            set
            {
                value3 = value;
            }
        }

        
        public BigInteger GetMyHashCode()
        {
            SHA256 mySHA256 = SHA256.Create();
            BigInteger hashA = new BigInteger(mySHA256.ComputeHash(Encoding.UTF8.GetBytes(a)));
            BigInteger hashB = new BigInteger(mySHA256.ComputeHash(Encoding.UTF8.GetBytes(b)));

            BigInteger hashValue1 = new BigInteger(mySHA256.ComputeHash(value1.ToByteArray()));
            BigInteger hashValue2 = new BigInteger(mySHA256.ComputeHash(value2.ToByteArray()));
            BigInteger hashValue3 = new BigInteger(mySHA256.ComputeHash(value3.ToByteArray()));

            BigInteger hashCode = new BigInteger(17);
            BigInteger primeNumber = new BigInteger(23);
            hashCode = hashCode * primeNumber + hashA;
            hashCode = hashCode * primeNumber + hashB;
            hashCode = hashCode * primeNumber + hashValue1;
            hashCode = hashCode * primeNumber + hashValue2;
            hashCode = hashCode * primeNumber + hashValue3;
            return hashCode;
        }
    }
}
