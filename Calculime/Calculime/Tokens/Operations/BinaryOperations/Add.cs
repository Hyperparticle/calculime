using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.BinaryOperations
{
    public class Add : BinaryOperation
    {
        public Add()
        {
            Symbol = "+";
            Precedence = (int)Priority.Low;
            LeftAssociative = true;
        }

        public override Value ExecuteBinary(Value value1, Value value2)
        {
            return value1 + value2;
        }
    }
}
