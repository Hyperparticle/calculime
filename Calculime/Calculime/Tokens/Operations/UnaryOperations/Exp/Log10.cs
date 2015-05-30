using System;
using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Exp
{
    public class Log10 : UnaryOperation
    {
        public Log10()
        {
            Symbol = Token.Log10;
        }

        public override Value ExecuteUnary(Value value)
        {
            value.Val = Math.Log10(value.Val);
            return value;
        }
    }
}
