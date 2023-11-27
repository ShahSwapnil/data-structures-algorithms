using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace algorithmTests.Utilities
{
    public static class LoggerExtensions
    {
        public static string ArrayAsString(this int[] numbers, int start = 0, int max = 0)
        {
            var heapValues = numbers.Select((value, index) => new { value, index });

            if (start > 0)
                heapValues = heapValues.Where(x => start <= x.index);

            if (max != 0)
                heapValues = heapValues.Where(x => x.index <= max);

                                                //.Where(x => 0 < x.index && x.index <= currentIdx)
                                                //.Select(x => x.value);

            return $"[{string.Join("|", heapValues.Select( x => x.value ))}]";
        }
    }
}
