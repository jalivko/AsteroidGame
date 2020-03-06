﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestConsole.Extensions
{
    static class Utils
    {
        public static IEnumerable<int> GetRandomIntValues(this Random rnd, int Count, int Min, int Max)
        {
            for (var i = 0; i < Count; i++)
            {
                yield return rnd.Next(Min, Max);
            }
        }

        public static TValue NextValue<TValue>(this Random rnd, params TValue[] values) => values[rnd.Next(0, values.Length)];

    }
}
