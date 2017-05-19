using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Probs
{
    class RollsGenerator
    {
        int[] _featValues;
        int[] _dieValues;

        public RollsGenerator()
        {
            _featValues = new int[] { 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12 };
            _dieValues = new int[] { 1, 2, 3, 4, 5, 6 };
        }

        public Roll[] GetAllRolls(int numberOfDie)
        {
            var rolls = _featValues
                .Select(v => new Roll(v))
                .ToArray();

            for (int i = 0; i < numberOfDie; i++)
            {
                var x = rolls.SelectMany(r => 
                {
                    return _dieValues.Select(d => 
                    {
                        return r.CloneWithAdditionDice(d);
                    });
                });

                rolls = x.ToArray();
            }

            return rolls;
        }
    }
}
