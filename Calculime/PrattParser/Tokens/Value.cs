using System;
using System.Collections.Generic;
using MathNet.Numerics;

namespace PrattParser.Tokens
{
    public class Value
    {
        public static readonly double Default = 0;

        private static readonly Dictionary<string, double> StringToConstant =
            new Dictionary<string, double>
            {
                {"pi", Math.PI},
                {"e", Math.E},
                {"sqrt2", Constants.Sqrt2},
                {"sqrt3", Constants.Sqrt3},
                {"phi", Constants.GoldenRatio},
                {"gamma", Constants.EulerMascheroni}
            };

        public static readonly Dictionary<string, double> UserConstants = new Dictionary<string, double>();

        public static bool IsValue(string name)
        {
            return (StringToConstant.ContainsKey(name) || UserConstants.ContainsKey(name));
        }

        public static double GetValue(string name)
        {
            double value;

            if (StringToConstant.TryGetValue(name, out value))
                return value;
            if (UserConstants.TryGetValue(name, out value))
                return value;

            throw new NotImplementedException(string.Format("The value {0} is not implemented.", name));
        }
    }
}
