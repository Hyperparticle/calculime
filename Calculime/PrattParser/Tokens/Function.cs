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
                { TokenType.Minus, Negate }
            };

        private static readonly Dictionary<FunctionType, MultiDelegate> TrigFunction =
            new Dictionary<FunctionType, MultiDelegate>()
            {
                { FunctionType.Sine, Sin },
                { FunctionType.Cosine, Cos },
                { FunctionType.Tangent, Tan },
                { FunctionType.Arcsine, Asin },
                { FunctionType.Arccosine, Acos },
                { FunctionType.Arctangent, Atan }
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

        // TRIGONOMETRIC FUNCTIONS

        private static double Sin(params double[] values)
        {
            if (values.Length != 1)
                throw new ParseException("Error: too many arguments.");

            return Math.Sin(values[0]);
        }

        private static double Cos(params double[] values)
        {
            if (values.Length != 1)
                throw new ParseException("Error: too many arguments.");

            return Math.Cos(values[0]);
        }

        private static double Tan(params double[] values)
        {
            if (values.Length != 1)
                throw new ParseException("Error: too many arguments.");

            return Math.Tan(values[0]);
        }

        private static double Asin(params double[] values)
        {
            if (values.Length != 1)
                throw new ParseException("Error: too many arguments.");

            return Math.Asin(values[0]);
        }

        private static double Acos(params double[] values)
        {
            if (values.Length != 1)
                throw new ParseException("Error: too many arguments.");

            return Math.Acos(values[0]);
        }

        private static double Atan(params double[] values)
        {
            if (values.Length != 1)
                throw new ParseException("Error: too many arguments.");

            return Math.Atan(values[0]);
        }
    }
}
