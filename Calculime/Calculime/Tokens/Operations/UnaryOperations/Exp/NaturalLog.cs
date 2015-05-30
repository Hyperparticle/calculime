using System;
using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Exp
{
    public class NaturalLog : UnaryOperation
    {
        public NaturalLog()
        {
            Symbol = Token.NaturalLog;
        }

        public override Value ExecuteUnary(Value value)
        {
            value.Val = Math.Log(value.Val);
            return value;
        }
    }
}
