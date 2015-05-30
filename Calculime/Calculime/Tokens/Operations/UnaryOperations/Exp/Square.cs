using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.UnaryOperations.Exp
{
    public class Square : UnaryOperation
    {
        public Square()
        {
            Symbol = "^2";
        }

        public override Value ExecuteUnary(Value value)
        {
            return value * value;
        }
    }
}
