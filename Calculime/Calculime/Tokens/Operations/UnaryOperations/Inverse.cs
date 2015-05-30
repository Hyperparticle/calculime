using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.UnaryOperations
{
    public class Inverse : UnaryOperation
    {
        public Inverse()
        {
            Symbol = "1/x";
        }

        public override Value ExecuteUnary(Value value)
        {
			value.Val = 1 / value.Val;
			return value;
        }
    }
}
