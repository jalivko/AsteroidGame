using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsteroidGame
{
    struct Interval<TValue>
    {
        public TValue Min { get; }

        public TValue Max { get; }

        public Interval(TValue _Min, TValue _Max)
        {
            Min = _Min;
            Max = _Max;
        }
    }
}
