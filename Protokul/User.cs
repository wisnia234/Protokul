using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Protokul
{
    class User
    {
        string name;
        private int esk;
        private int sk;
        BigInteger pk;
        const int q = 5;
        BigInteger key;

        public User(string name, RandomGenerator randomGenerator)
        {
            this.name = name;
            int lambda = 5;
            int minValue = 1;
            
            for (int i = 0; i < lambda - 1; i++)
            {
                minValue *= 10;
            }

            int maxValue = (minValue * 10);

            esk = randomGenerator.Next(minValue, maxValue);
            sk = randomGenerator.Next(1,q);

            int g = 5;
            pk = BigInteger.Pow(new BigInteger(g), sk) % q;
        }

        public BigInteger PublicKey => pk;
        public string Name => name;

        public BigInteger Send
        {
            get
            {
                int g = q;
                return BigInteger.Pow(new BigInteger(g), new H1(esk, sk).GetHashCode(q)) % q;
            }
        }
        
        public void GenerateKeyFirstPerson(string userName, BigInteger data, BigInteger publicKey)
        {
            H2 generator = new H2(name, userName);
            generator.Value1 = BigInteger.Pow(data, sk);
            generator.Value2 = BigInteger.Pow(publicKey, new H1(esk, sk).GetHashCode(q));
            generator.Value3 = BigInteger.Pow(data, new H1(esk, sk).GetHashCode(q));

            key = generator.GetMyHashCode();
        }
        public void GenerateKeySecondPerson(string userName, BigInteger data, BigInteger publicKey)
        {
            H2 generator = new H2(userName, name);
            generator.Value1 = BigInteger.Pow(publicKey, new H1(esk, sk).GetHashCode(q));
            generator.Value2 = BigInteger.Pow(data, sk);
            generator.Value3 = BigInteger.Pow(data, new H1(esk, sk).GetHashCode(q));

            key = generator.GetMyHashCode();
        }

        public BigInteger Key => key;
      

    }
}
