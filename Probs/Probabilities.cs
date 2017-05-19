using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Probs
{
    class Probabilities
    {
        readonly ProbabilityGenerator _probabilityGenerator;

        public Probabilities()
        {
            _probabilityGenerator = new ProbabilityGenerator();
        }

        public void Go()
        {
            OutputTNs(new int[] { 8, 10, 12, 14, 16, 18 });

            Output(0, new int[] { 8, 10, 12, 14, 16, 18});
            Output(1, new int[] { 8, 10, 12, 14, 16, 18 });
            Output(2, new int[] { 8, 10, 12, 14, 16, 18 });
            Output(3, new int[] { 8, 10, 12, 14, 16, 18 });
            Output(4, new int[] { 8, 10, 12, 14, 16, 18 });
            Output(5, new int[] { 8, 10, 12, 14, 16, 18 });
            Output(6, new int[] { 8, 10, 12, 14, 16, 18 });
        }

        void Output(int dice, int[] tns)
        {
            double[] successProbability = _probabilityGenerator.GetProbabilities(dice, tns);

            string[] probs = successProbability.Select(p => string.Format("{0,5:0%}", p))
                .ToArray();

            string text = string.Join("", probs);

            Console.WriteLine("feat+{0}d6 => {1}", dice, text);
        }

        void OutputTNs(int[] tns)
        {
            string[] probs = tns.Select(p => string.Format("{0,5}", p))
                .ToArray();

            string text = string.Join("", probs);

            Console.WriteLine("            {0}", text);
        }

        void Output(int dice, int tn)
        {
            double successProbability = _probabilityGenerator.GetProbability(dice, tn);

            Console.WriteLine("{0}d6 => {1:0%}", dice, successProbability);
        }

        void OutputAllRolls(Roll[] rolls)
        {
            foreach (var roll in rolls)
            {
                Console.WriteLine(roll);
            }
        }
    }
}
