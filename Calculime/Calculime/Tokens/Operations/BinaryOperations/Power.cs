using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.BinaryOperations
{
    public class Power : BinaryOperation
    {
		public Power()
        {
            Symbol = "^";
			Precedence = (int)Priority.High;
			LeftAssociative = false;
        }

        public override Value ExecuteBinary(Value value1, Value value2)
        {
            return value1 ^ value2;
        }
    }
}
