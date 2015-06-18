using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrattParser.Tokens
{
    public class Value
    {
        public static readonly double Default = 0;

        public static readonly Dictionary<string, double> StringToValue =
            new Dictionary<string, double>
            {
                { "pi", Math.PI },
                { "e", Math.E }
            };
    }
}
