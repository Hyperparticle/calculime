using System;
using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Trig
{
    public class Tangent : UnaryOperation
    {
        public Tangent()
        {
            Symbol = Token.Tangent;
        }

        public override Value ExecuteUnary(Value value)
        {
            value.Val = Math.Tan(value.Val);
            return value;
        }
    }
}
