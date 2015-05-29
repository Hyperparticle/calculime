using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.BinaryOperations
{
    public class Subtract : BinaryOperation
    {
        public Subtract()
        {
            Symbol = "-";
            Precedence = (int)Priority.Low;
            LeftAssociative = true;
        }

        public override Value ExecuteBinary(Value value1, Value value2)
        {
            return value1 - value2;
        }
    }
}
