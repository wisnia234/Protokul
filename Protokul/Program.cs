using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Protokul
{
    class Program
    {
        static void Main(string[] args)
        {
    
            RandomGenerator randomGenerator = new RandomGenerator();
            
            User user1 = new User("A", randomGenerator);
            User user2 = new User("B", randomGenerator);

            user1.GenerateKeyFirstPerson(user2.Name, user2.Send,user2.PublicKey);
            user2.GenerateKeySecondPerson(user1.Name, user1.Send, user1.PublicKey);

            Console.WriteLine(user1.Key);
            Console.WriteLine(user2.Key);

            Console.ReadKey();

        }
    }
}
