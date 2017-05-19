using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;

namespace Probs
{
    class SuccessCalculator
    {
        public SuccessCalculator(RollOutcomeGenerator rollOutcomeGenerator)
        {
            RollOutcomeGenerator = rollOutcomeGenerator;
        }

        public RollOutcomeGenerator RollOutcomeGenerator { get; private set; }

        public double SuccessProbability(Roll[] rolls)
        {
            var outcomes = rolls.Select(RollOutcomeGenerator.Determine);

            int successes = outcomes.Where(o => o.IsAnySuccess).Count();
            int total = outcomes.Count();

            double prob = (double)successes / total;

            return prob;
        }
    }
}
