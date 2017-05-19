using System;
using System.Collections.Generic;
using System.Text;

namespace Probs
{
    class CachedRollsGenerator
    {
        readonly RollsGenerator _rollsGenerator;
        readonly Dictionary<int, Roll[]> _cache;

        public CachedRollsGenerator()
        {
            _rollsGenerator = new RollsGenerator();
            _cache = new Dictionary<int, Roll[]>();
        }

        public Roll[] GetAllRolls(int numberOfDie)
        {
            if (_cache.ContainsKey(numberOfDie))
                return _cache[numberOfDie];

            Roll[] rolls = _rollsGenerator.GetAllRolls(numberOfDie);
            _cache.Add(numberOfDie, rolls);

            return rolls;
        }
    }
}
