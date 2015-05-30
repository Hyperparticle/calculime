using System;
using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Trig
{
    public class Cosine : UnaryOperation
    {
        public Cosine()
        {
            Symbol = Token.Cosine;
        }

        public override Value ExecuteUnary(Value value)
        {
            value.Val = Math.Cos(value.Val);
            return value;
        }
    }
}
