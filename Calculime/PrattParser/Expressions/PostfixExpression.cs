using System;
using System.Text;
using PrattParser.Tokens;

namespace PrattParser.Expressions
{
    /**
     * A postfix unary arithmetic expression like "a!".
     */
    public class PostfixExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly TokenType _operator;

        public PostfixExpression(IExpression left, TokenType type)
        {
            _left = left;
            _operator = type;
        }

        public double Execute()
        {
            throw new NotImplementedException();
        }

        public void Print(StringBuilder builder)
        {
            builder.Append("(");
            _left.Print(builder);
            builder.Append(Table.TokenTypeToChar[_operator]).Append(")");
        }
    }
}
