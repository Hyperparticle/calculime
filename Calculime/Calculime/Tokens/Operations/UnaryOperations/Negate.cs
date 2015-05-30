using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.UnaryOperations
{
    public class Negate : UnaryOperation
    {
        public Negate()
        {
            Symbol = "-/+";
        }

        public override Value ExecuteUnary(Value value)
        {
            return -value;
        }
    }
}
