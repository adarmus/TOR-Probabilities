using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Probs
{
    class RollOutcomeGenerator
    {
        public RollOutcomeGenerator(int tn)
        {
            this.TN = tn;
        }

        public int TN { get; set; }

        public RollOutcome Determine(Roll roll)
        {
            bool hasMetTN = HasMetTN(roll);

            if (hasMetTN)
            {
                int sixes = NumberOf6s(roll);
                if (sixes == 0)
                    return new RollOutcome(RollOutcomeStatus.OrdinarySuccess);
                else if (sixes == 1)
                    return new RollOutcome(RollOutcomeStatus.GreatSuccess);
                return new RollOutcome(RollOutcomeStatus.ExtraordinarySuccess);
            }
            else
            {
                return new RollOutcome(RollOutcomeStatus.Fail);
            }
        }

        int NumberOf6s(Roll roll)
        {
            return roll.Dice
                .Where(d => d == 6)
                .Count();
        }

        bool HasRolled12(Roll roll)
        {
            return roll.Feat == 12;
        }

        bool HasMetTN(Roll roll)
        {
            bool hasRolled12 = HasRolled12(roll);

            if (hasRolled12)
                return true;

            return GetTotal(roll) >= TN;
        }

        int GetTotal(Roll roll)
        {
            int total = GetFeatValue(roll) + roll.Dice.Sum();
            return total;
        }

        int GetFeatValue(Roll roll)
        {
            if (roll.Feat == 11)
                return 0;

            return roll.Feat;
        }
    }
}
