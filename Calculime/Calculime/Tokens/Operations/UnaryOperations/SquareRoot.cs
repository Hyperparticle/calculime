using System;
using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.UnaryOperations
{
    public class SquareRoot : UnaryOperation
    {
        public SquareRoot()
        {
            Symbol = "SQRT";
        }

        public override Value ExecuteUnary(Value value)
        {
			value.Val = Math.Sqrt(value.Val);
            return value;
        }
    }
}
