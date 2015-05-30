using System;
using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Trig
{
    public class Arcsine : UnaryOperation
    {
        public Arcsine()
        {
            Symbol = Token.Arcsine;
        }

        public override Value ExecuteUnary(Value value)
        {
            value.Val = Math.Asin(value.Val);
            return value;
        }
    }
}
