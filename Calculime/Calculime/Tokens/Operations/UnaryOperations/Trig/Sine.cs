using System;
using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Trig
{
    public class Sine : UnaryOperation
    {
        public Sine()
        {
            Symbol = Token.Sine;
        }

        public override Value ExecuteUnary(Value value)
        {
            value.Val = Math.Sin(value.Val);
            return value;
        }
    }
}
