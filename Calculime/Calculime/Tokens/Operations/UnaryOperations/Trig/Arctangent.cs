using System;
using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Trig
{
    public class Arctangent : UnaryOperation
    {
        public Arctangent()
        {
            Symbol = Token.Arctangent;
        }

        public override Value ExecuteUnary(Value value)
        {
            value.Val = Math.Atan(value.Val);
            return value;
        }
    }
}
