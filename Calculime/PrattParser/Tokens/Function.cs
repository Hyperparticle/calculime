using System;
using System.Collections.Generic;
using System.Xml.Linq;
using PrattParser.Exceptions;

namespace PrattParser.Tokens
{
    public class Function
    {
        private delegate double UnaryDelegate(double value);
        private delegate double BinaryDelegate(double value1, double value2);
        private delegate double MultiDelegate(params double[] values);

        private static readonly Dictionary<TokenType, UnaryDelegate> UnaryOperator =
            new Dictionary<TokenType, UnaryDelegate>
            {
                { TokenType.Plus, x => x },
                { TokenType.Minus, x => -x },
                { TokenType.Bang, Factorial },
                { TokenType.Tilde, x => ~(int)x }
            };
        private static readonly Dictionary<TokenType, BinaryDelegate> BinaryOperator =
            new Dictionary<TokenType, BinaryDelegate>
            {
                { TokenType.Plus, (x,y) => x + y },
                { TokenType.Minus, (x,y) => x - y },
                { TokenType.Asterisk, (x,y) => x * y },
                { TokenType.Slash, (x,y) => x / y },
                { TokenType.Caret, Math.Pow },
                { TokenType.Percent, (x,y) => x % y },
                { TokenType.Ampersand, (x,y) => (int)x & (int)y },
                { TokenType.Pipe, (x,y) => (int)x | (int)y },
                { TokenType.BitLeft, (x,y) => (int)x << (int)y },
                { TokenType.BitRight, (x,y) => (int)x >> (int)y },
            };

        private static readonly Dictionary<string, UnaryDelegate> UnaryFunction =
            new Dictionary<string, UnaryDelegate>
            {
                { "sin",  Math.Sin },
                { "cos", Math.Cos },
                { "tan", Math.Tan },
                { "asin", Math.Asin },
                { "acos", Math.Acos },
                { "atan", Math.Atan },
                { "sinh",  Math.Sinh },
                { "cosh", Math.Cosh },
                { "tanh", Math.Tanh },
                { "abs", Math.Abs },
                { "ln", Math.Log },
                { "log", Math.Log },
                { "log10", Math.Log10 },
                { "sqrt", Math.Sqrt },
                { "round", Math.Round },
                { "floor", Math.Floor },
                { "ceil", Math.Ceiling },
                { "ceiling", Math.Ceiling },
                { "prev", Memory.GetResult }
            };

        private static readonly Dictionary<string, BinaryDelegate> BinaryFunction =
            new Dictionary<string, BinaryDelegate>
            {
                { "min",  Math.Min },
                { "max", Math.Max },
                { "rem", (x,y) => x % y },
                { "remainder", (x,y) => x % y }
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
                case 1:
                    return UnaryFunction[function].Invoke(args[0]);
                case 2:
                    return BinaryFunction[function].Invoke(args[0], args[1]);
                default:
                    throw new NotImplementedException();
            }
        }

        // CUSTOM FUNCTIONS
        private static double Factorial(double value)
        {
            double result = 1;
            for (var i = 2; i <= value; i++)
            {
                result *= i;
            }

            return result;
        }

        private static void TestArgs(int number, int expected)
        {
            if (number != expected)
                throw new ParseException("Error: incorrect number of arguments. " +
                                         "Expected " + expected + ". Got " + number);
        }
    }
}
