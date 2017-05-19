using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Probs
{
    class Roll
    {
        public Roll(int featValue)
        {
            this.Feat = featValue;
            this.Dice = new int[] { };
        }

        public int Feat { get; set; }

        public int[] Dice { get; set; }

        public Roll CloneWithAdditionDice(int d)
        {
            var newRoll = new Roll(this.Feat);

            var newDice = this.Dice.Concat(new int[] { d }).ToArray();

            newRoll.Dice = newDice;

            return newRoll;
        }

        public override string ToString()
        {
            string s = string.Format("{0} + [{1}]", this.Feat, string.Join(", ", this.Dice));
            return s;
        }
    }
}
