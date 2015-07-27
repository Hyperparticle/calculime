using System.Collections.Generic;
using System.Linq;
using System.Text;
using PrattParser.Tokens;

namespace PrattParser.Expressions
{
    /// <summary>
    /// A function expression like "sin(pi)".
    /// </summary>
    public class FunctionExpression : IExpression
    {
        private readonly string _functionName;
        private readonly List<IExpression> _args;

        public FunctionExpression(string function, List<IExpression> args)
        {
            _functionName = function;
            _args = args;
        }

        public double Calculate()
        {
            // Calculate all arguments before proceeding
            var args = _args.Select(x => x.Calculate()).ToArray();

            return Function.Execute(_functionName.ToLower(), args);
        }

        public void Print(StringBuilder builder)
        {
            builder.Append(_functionName);
            builder.Append("(");
            for (var i = 0; i < _args.Count; i++)
            {
                _args[i].Print(builder);
                if (i < _args.Count - 1) builder.Append(", ");
            }
            builder.Append(")");
        }
    }
}
