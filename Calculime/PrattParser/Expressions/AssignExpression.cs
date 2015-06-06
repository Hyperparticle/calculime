using System;
using System.Text;

namespace PrattParser.Expressions
{
    /**
     * An assignment expression like "a = b".
     */
    public class AssignExpression : IExpression
    {
        private readonly string _name;
        private readonly IExpression _right;

        public AssignExpression(string name, IExpression right)
        {
            _name = name;
            _right = right;
        }

        public double Execute(params IExpression[] inputs)
        {
            throw new NotImplementedException();
        }

        public void Print(StringBuilder builder)
        {
            builder.Append("(").Append(_name).Append(" = ");
            _right.Print(builder);
            builder.Append(")");
        }
    }
}
