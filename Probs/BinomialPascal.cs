using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Probs
{
    class BinomialPascal
    {
        const int WIDTH = 30;

        public void Go()
        {
            int[] current = new int[] { };

            for (int i = 0; i < 9; i++)
            {
                int[] perms = GetPermutations(current);

                Output(perms);

                current = perms;
            }
        }

        void Output(int[] perms)
        {
            string text = string.Join(" ", perms);

            int pad = WIDTH - (text.Length /  2);
            string padding = pad > 0 ? new string(' ', pad) : string.Empty;
            Console.WriteLine("{0}{1}", padding, text);
        }

        int[] GetPermutations(int[] input)
        {
            if (input.Length == 0)
                return new int[] { 1 };

            int[] output = new int[input.Length + 1];

            for (int i = 0; i < output.Length; i++)
            {
                output[i] = GetNewValue(input, i);
            }

            return output;
        }

        int GetNewValue(int[] input, int i)
        {
            if (i == 0 || i >= input.Length)
                return 1;

            int x = input[i - 1] + input[i];

            return x;
        }
    }
}
