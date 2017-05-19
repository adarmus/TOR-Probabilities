using System;
using System.Collections.Generic;
using System.Text;

namespace Probs
{
    class MathEx
    {
        public static int Fact(int x)
        {
            int fact = 1;

            for (int i = 1; i <= x; i++)
            {
                fact = fact * i;
            }

            return fact;
        }
    }
}
