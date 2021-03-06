﻿using System.Text;
using PrattParser.Tokens;

namespace PrattParser.Expressions
{
    /**
     * A prefix unary arithmetic expression like "!a" or "-b".
     */
    public class PrefixExpression : IExpression
    {
        private readonly TokenType _operator;
        private readonly IExpression _right;

        public PrefixExpression(TokenType type, IExpression right)
        {
            _operator = type;
            _right = right;
        }

        public double Calculate()
        {
            return Function.Execute(_operator, _right.Calculate());
        }

        public void Print(StringBuilder builder)
        {
            builder.Append("(").Append(Table.TokenTypeToString[_operator]);
            _right.Print(builder);
            builder.Append(")");
        }
    }
}
