using System;
using System.Collections.Generic;
using System.Linq;
using MathNet.Numerics;
using MathNet.Numerics.Statistics;

namespace PrattParser.Tokens
{
    /// <summary>
    /// The Function class maps input to output. It takes user input, executes
    /// the appropriate function, and produces a valued output.
    /// </summary>
    public class Function
    {
        private static readonly Random Rand = new Random();

        private delegate double NullaryDelegate();
        private delegate double UnaryDelegate(double value);
        private delegate double BinaryDelegate(double value1, double value2);
        private delegate double MultiDelegate(params double[] values);

        private static readonly Dictionary<TokenType, UnaryDelegate> UnaryOperator =
            new Dictionary<TokenType, UnaryDelegate>
            {
                {TokenType.Plus, x => x},
                {TokenType.Minus, x => -x},
                {TokenType.Bang, Factorial},
                {TokenType.Tilde, x => ~(long) x}
            };

        private static readonly Dictionary<TokenType, BinaryDelegate> BinaryOperator =
            new Dictionary<TokenType, BinaryDelegate>
            {
                {TokenType.Plus, (x, y) => x + y},
                {TokenType.Minus, (x, y) => x - y},
                {TokenType.Asterisk, (x, y) => x*y},
                {TokenType.Slash, (x, y) => x/y},
                {TokenType.Caret, Math.Pow},
                {TokenType.Percent, (x, y) => x%y},
                {TokenType.Ampersand, (x, y) => (long) x & (long) y},
                {TokenType.Pipe, (x, y) => (long) x | (long) y},
                {TokenType.BitLeft, (x, y) => (long) x << (int) y},
                {TokenType.BitRight, (x, y) => (long) x >> (int) y},
            };

        private static readonly Dictionary<string, NullaryDelegate> NullaryFunction =
            new Dictionary<string, NullaryDelegate>
            {
                {"rand", Rand.NextDouble}
            };

        private static readonly Dictionary<string, UnaryDelegate> UnaryFunction =
            new Dictionary<string, UnaryDelegate>
            {
                {"sin", Math.Sin},
                {"cos", Math.Cos},
                {"tan", Math.Tan},
                {"asin", Math.Asin},
                {"acos", Math.Acos},
                {"atan", Math.Atan},
                {"sinh", Math.Sinh},
                {"cosh", Math.Cosh},
                {"tanh", Math.Tanh},
                {"abs", Math.Abs},
                {"ln", Math.Log},
                {"log", Math.Log},
                {"log10", Math.Log10},
                {"sqrt", Math.Sqrt},
                {"round", Math.Round},
                {"floor", Math.Floor},
                {"ceil", Math.Ceiling},
                {"ceiling", Math.Ceiling},
                {"prev", Memory.GetResult},
                {"degtorad", Trig.DegreeToRadian},
                {"radtodeg", Trig.RadianToDegree}
            };

        private static readonly Dictionary<string, BinaryDelegate> BinaryFunction =
            new Dictionary<string, BinaryDelegate>
            {
                {"atan2", Math.Atan2},
                {"rem", Euclid.Remainder},
                {"mod", Euclid.Modulus},
                {"hyp", SpecialFunctions.Hypotenuse}
            };

        private static readonly Dictionary<string, MultiDelegate> MultiFunction =
            new Dictionary<string, MultiDelegate>
            {
                {"min", x => x.Min()},
                {"max", x => x.Max()},
                {"sum", x => x.Sum()},
                {"avg", x => x.Average()},
                {"count", x => x.Count()},
                {"mean", Statistics.Mean},
                {"median", Statistics.Median},
                {"variance", Statistics.Variance},
                {"stdev", Statistics.StandardDeviation}
            };

        // Overloaded execute command to handle different cases
        public static double Execute(double left, TokenType type, double right)
        {
            return BinaryOperator[type].Invoke(left, right);
        }

        public static double Execute(TokenType type, double right)
        {
            return UnaryOperator[type].Invoke(right);
        }

        public static double Execute(string function, params double[] args)
        {
            switch (args.Length)
            {
                case 0:
                    NullaryDelegate nullary;
                    if (NullaryFunction.TryGetValue(function, out nullary))
                        return nullary.Invoke();
                    break;
                case 1:
                    UnaryDelegate unary;
                    if (UnaryFunction.TryGetValue(function, out unary))
                        return unary.Invoke(args[0]);
                    break;
                case 2:
                    BinaryDelegate binary;
                    if (BinaryFunction.TryGetValue(function, out binary))
                        return binary.Invoke(args[0], args[1]);
                    break;
            }

            return MultiFunction[function].Invoke(args);
        }

        // SPECIAL FUNCTIONS
        private static double Factorial(double value)
        {
            return SpecialFunctions.Factorial((int) value);
        }
    }
}
