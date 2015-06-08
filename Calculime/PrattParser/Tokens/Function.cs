using System;
using System.Collections.Generic;
using PrattParser.Exceptions;

namespace PrattParser.Tokens
{
    public class Function
    {
        private static readonly Dictionary<TokenType, BinaryDelegate> BinaryFunction =
            new Dictionary<TokenType, BinaryDelegate>()
            {
                { TokenType.Plus, Add },
                { TokenType.Minus, Subtract },
                { TokenType.Asterisk, Multiply },
                { TokenType.Slash, Divide },
                { TokenType.Caret, Exponentiate }
            };

        private static readonly Dictionary<TokenType, UnaryDelegate> UnaryFunction =
            new Dictionary<TokenType, UnaryDelegate>()
            {
                { TokenType.Plus, Identity },
                { TokenType.Minus, Negate },
                { TokenType.Bang, Factorial }
            };

        private static readonly Dictionary<FunctionType, MultiDelegate> TrigFunction =
            new Dictionary<FunctionType, MultiDelegate>()
            {
                { FunctionType.Sine, Sin },
                { FunctionType.Cosine, Cos },
                { FunctionType.Tangent, Tan },
                { FunctionType.Arcsine, Asin },
                { FunctionType.Arccosine, Acos },
                { FunctionType.Arctangent, Atan },
                { FunctionType.AbsoluteValue, Abs },
                { FunctionType.NaturalLog, Log },
                { FunctionType.LogBase10, Log10 },
                { FunctionType.SquareRoot, Sqrt },
                { FunctionType.Round, Round },
                { FunctionType.Floor, Floor },
                { FunctionType.Ceiling, Ceiling },
                { FunctionType.Max, Max },
                { FunctionType.Min, Min }
            };

        public static double Execute(double left, TokenType type, double right)
        {
            return BinaryFunction[type].Invoke(left, right);
        }

        public static double Execute(TokenType type, double right)
        {
            return UnaryFunction[type].Invoke(right);
        }

        public static double Execute(FunctionType type, params double[] args)
        {
            return TrigFunction[type].Invoke(args);
        }

        private delegate double UnaryDelegate(double value);
        private delegate double BinaryDelegate(double value1, double value2);
        private delegate double MultiDelegate(params double[] values);


        // TOKEN FUNCTIONS
        // Binary functions

        private static double Add(double value1, double value2)
        {
            return value1 + value2;
        }

        private static double Subtract(double value1, double value2)
        {
            return value1 - value2;
        }

        private static double Multiply(double value1, double value2)
        {
            return value1 * value2;
        }

        private static double Divide(double value1, double value2)
        {
            return value1 / value2;
        }

        private static double Exponentiate(double value1, double value2)
        {
            return Math.Pow(value1, value2);
        }

        // Unary functions

        private static double Identity(double value)
        {
            return value;
        }

        private static double Negate(double value)
        {
            return -value;
        }

        private static double Factorial(double value)
        {
            value = Math.Round(value);
            return (value <= 1) ? 1 : value*Factorial(value - 1);
        }

        // TRIGONOMETRIC FUNCTIONS

        private static double Sin(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Sin(values[0]);
        }

        private static double Cos(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Cos(values[0]);
        }

        private static double Tan(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Tan(values[0]);
        }

        private static double Asin(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Asin(values[0]);
        }

        private static double Acos(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Acos(values[0]);
        }

        private static double Atan(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Atan(values[0]);
        }

        // ALGEBRAIC FUNCTIONS

        private static double Abs(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Abs(values[0]);
        }

        private static double Log(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Log(values[0]);
        }

        private static double Log10(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Log10(values[0]);
        }

        private static double Sqrt(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Sqrt(values[0]);
        }

        private static double Round(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Round(values[0]);
        }

        private static double Floor(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Floor(values[0]);
        }

        private static double Ceiling(params double[] values)
        {
            TestArgs(values.Length, 1);
            return Math.Ceiling(values[0]);
        }

        // COMPARISON FUNCTIONS

        private static double Max(params double[] values)
        {
            TestArgs(values.Length, 2);
            return Math.Max(values[0], values[1]);
        }

        private static double Min(params double[] values)
        {
            TestArgs(values.Length, 2);
            return Math.Min(values[0], values[1]);
        }

        private static void TestArgs(int number, int expected)
        {
            if (number != expected)
                throw new ParseException("Error: incorrect number of arguments. " +
                                         "Expected " + expected + ". Got " + number);
        }
    }
}
