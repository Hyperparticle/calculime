using System;
using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Trig
{
    public class Arccosine : UnaryOperation
    {
        public Arccosine()
        {
            Symbol = Token.Arccosine;
        }

        public override Value ExecuteUnary(Value value)
        {
            value.Val = Math.Acos(value.Val);
            return value;
        }
    }
}
