using System.Collections.Generic;
using System.Text;
using PrattParser.Exceptions;

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

        public double Execute()
        {
            // Implicitly multiply if number preceeds group expression
            if (_function is NumberExpression)
            {
                if (_args.Count > 1)
                    throw new ParseException("Error: multiple arguments not allowed for implicit multiplication.");
                return _function.Execute() * _args[0].Execute();
            }

            return _function.Execute();
        }

        public void Print(StringBuilder builder)
        {
            _function.Print(builder);
            builder.Append("(");
            for (int i = 0; i < _args.Count; i++)
            {
                _args[i].Print(builder);
                if (i < _args.Count - 1) builder.Append(", ");
            }
            builder.Append(")");
        }
    }
}
