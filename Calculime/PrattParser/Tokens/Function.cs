using System;
using System.Collections.Generic;
using PrattParser.Expressions;

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
                { TokenType.Plus, Identity},
                { TokenType.Minus, Negate }
            };

        public static double Execute(double left, TokenType type, double right)
        {
            return BinaryFunction[type].Invoke(left, right);
        }

        public static double Execute(TokenType type, double right)
        {
            return UnaryFunction[type].Invoke(right);
        }

        private delegate double UnaryDelegate(double value);
        private delegate double BinaryDelegate(double value1, double value2);

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
    }
}
