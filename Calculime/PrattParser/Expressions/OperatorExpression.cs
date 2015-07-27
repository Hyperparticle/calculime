using System.Text;
using PrattParser.Tokens;

namespace PrattParser.Expressions
{
    /**
     * A binary arithmetic expression like "a + b" or "c ^ d".
     */
    public class OperatorExpression : IExpression
    {
        private readonly IExpression _left;
        private readonly TokenType _operator;
        private readonly IExpression _right;

        public OperatorExpression(IExpression left, TokenType type, IExpression right)
        {
            _left = left;
            _operator = type;
            _right = right;
        }

        public double Calculate()
        {
            return Function.Execute(_left.Calculate(), _operator, _right.Calculate());
        }

        public void Print(StringBuilder builder)
        {
            builder.Append("(");
            _left.Print(builder);
            builder.Append(" ").Append(Table.TokenTypeToString[_operator]).Append(" ");
           _right.Print(builder);
            builder.Append(")");
        }
    }
}
