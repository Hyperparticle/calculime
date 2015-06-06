using System;
using System.Text;
using PrattParser2.Tokens;

namespace PrattParser2.Expressions
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
            builder.Append(Table.DTokenString[_operator]).Append(")");
        }
    }
}
