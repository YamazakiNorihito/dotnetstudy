using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks.Dataflow;

namespace Study
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.Write(MakeDistributionKey("yamazaki"));
        }


        private static readonly int[] Weights = { 3, 1 };
        private static int MakeDistributionKey(string value)
        {
            unchecked
            {
                // The modulo 10 weight 3 based.
                var sum = 0;
                for (var i = 0; i < value.Length; i++)
                {
                    var c = (int)value[i];
                    sum += c * Weights[i % 2];
                }

                var digit = 10 - (sum % 10);
                return digit % 10;
            }
        }
    }

}
