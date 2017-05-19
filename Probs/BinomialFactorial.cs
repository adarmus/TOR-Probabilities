using System;
using System.Collections.Generic;
using System.Text;

namespace Probs
{
    class BinomialFactorial
    {
        const int WIDTH = 30;

        public void Go()
        {
            for (int n = 0; n < 9; n++)
            {
                int[] perms = new int[n + 1];

                for (int r = 0; r < n + 1; r++)
                {
                    perms[r] = Combinations(n, r);
                }

                Output(perms);
            }
        }

        int Combinations(int n, int r)
        {
            return MathEx.Fact(n) / (MathEx.Fact(r) * MathEx.Fact(n - r));
        }

        void Output(int[] perms)
        {
            string text = string.Join(" ", perms);

            int pad = WIDTH - (text.Length / 2);
            string padding = pad > 0 ? new string(' ', pad) : string.Empty;
            Console.WriteLine("{0}{1}", padding, text);
        }
    }
}
