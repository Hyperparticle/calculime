using System;
using System.Collections.Generic;
using MathNet.Numerics;

namespace PrattParser.Tokens
{
    public class Value
    {
        public static readonly double Default = 0;

        public static readonly Dictionary<string, double> StringToConstant =
            new Dictionary<string, double>
            {
                {"pi", Math.PI},
                {"e", Math.E},
                {"sqrt2", Constants.Sqrt2},
                {"sqrt3", Constants.Sqrt3},
                {"phi", Constants.GoldenRatio},
                {"gamma", Constants.EulerMascheroni}
            };
    }
}
