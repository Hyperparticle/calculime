using System;
using System.Text;

namespace PrattParser.Expressions
{
    /**
     * A ternary conditional expression like "a ? b : c".
     */
    public class ConditionalExpression : IExpression
    {
        private readonly IExpression _condition;
        private readonly IExpression _thenArm;
        private readonly IExpression _elseArm;

        public ConditionalExpression(IExpression condition, IExpression thenArm, IExpression elseArm)
        {
            _condition = condition;
            _thenArm = thenArm;
            _elseArm = elseArm;
        }

        public double Execute(params IExpression[] inputs)
        {
            throw new NotImplementedException();
        }

        public void Print(StringBuilder builder)
        {
            builder.Append("(");
            _condition.Print(builder);
            builder.Append(" ? ");
            _thenArm.Print(builder);
            builder.Append(" : ");
            _elseArm.Print(builder);
            builder.Append(")");
        }
    }
}
