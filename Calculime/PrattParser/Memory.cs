using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrattParser.Tokens;

namespace PrattParser
{
    public class Memory
    {
        // Keep a list of outputted results
        private static readonly List<double> Results = new List<double>();    

        public static void AddResult(double result)
        {
            Results.Add(result);
        }

        public static double GetResult(double index)
        {
            var i = (int) index + 1;

            if (i > 0 && i <= Results.Count)
            {
                return Results[Results.Count - i];
            }

            return Value.Default;
        }
    }
}
