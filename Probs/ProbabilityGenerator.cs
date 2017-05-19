using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Probs
{
    public class ProbabilityGenerator
    {
        readonly CachedRollsGenerator _rollsGenerator;

        public ProbabilityGenerator()
        {
            _rollsGenerator = new CachedRollsGenerator();
        }

        public double GetProbability(int dice, int tn)
        {
            var outcome = new RollOutcomeGenerator(tn);
            var calculator = new SuccessCalculator(outcome);

            var rolls = _rollsGenerator.GetAllRolls(dice);

            double successProbability = calculator.SuccessProbability(rolls);

            return successProbability;
        }

        public double[] GetProbabilities(int dice, int[] tns)
        {
            var probabilities = tns.Select(tn => { return GetProbability(dice, tn); })
                .ToArray();

            return probabilities;
        }
    }
}
