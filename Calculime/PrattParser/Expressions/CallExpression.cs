using System.Collections.Generic;
using System.Text;

namespace PrattParser.Expressions
{
    /**
     * An assignment expression like "a = b".
     */
    public class CallExpression : IExpression
    {
        private readonly IExpression _function;
        private readonly List<IExpression> _args;

        public CallExpression(IExpression function, List<IExpression> args)
        {
            _function = function;
            _args = args;
        }

        public void Print(StringBuilder builder)
        {
            _function.Print(builder);
            builder.Append("(");
            for (int i = 0; i < _args.Count; i++)
            {
                _args[i].Print(builder);
                if (i < _args.Count - 1) builder.Append(",");
            }
            builder.Append(")");
        }
    }
}
