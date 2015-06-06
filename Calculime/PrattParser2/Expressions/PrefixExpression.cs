﻿using System.Text;
using PrattParser2.Tokens;

namespace PrattParser2.Expressions
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

        public double Execute()
        {
            return Function.Execute(_operator, _right.Execute());
        }

        public void Print(StringBuilder builder)
        {
            builder.Append("(").Append(Table.DTokenString[_operator]);
            _right.Print(builder);
            builder.Append(")");
        }
    }
}