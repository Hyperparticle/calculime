using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.BinaryOperations
{
    public class Subtract : BinaryOperation
    {
        public Subtract()
        {
            Symbol = Token.Subtract;
            Precedence = (int)Priority.Low;
            LeftAssociative = true;
        }

        public override Value ExecuteBinary(Value value1, Value value2)
        {
            return value1 - value2;
        }
    }
}
