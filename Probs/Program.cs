using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Probs
{
    class Program
    {
        static void Main(string[] args)
        {
            var prob = new Probabilities();
            prob.Go();

            //var fact = new BinomialFactorial();
            //fact.Go();

            //Console.WriteLine();

            //var dice = new BinomialPascal();
            //dice.Go();

            Console.WriteLine();
            Console.WriteLine("Press any key to exit");
            Console.ReadKey();
        }
    }
}
