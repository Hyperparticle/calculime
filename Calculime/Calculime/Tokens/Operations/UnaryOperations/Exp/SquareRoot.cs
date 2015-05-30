using System;
using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Exp
{
    public class SquareRoot : UnaryOperation
    {
        public SquareRoot()
        {
            Symbol = Token.SquareRoot;
        }

        public override Value ExecuteUnary(Value value)
        {
			value.Val = Math.Sqrt(value.Val);
            return value;
        }
    }
}
