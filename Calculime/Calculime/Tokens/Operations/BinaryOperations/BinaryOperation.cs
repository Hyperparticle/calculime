using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.BinaryOperations
{
    public abstract class BinaryOperation : Operation
    {
        protected BinaryOperation()
        {
            NumArguments = 2;
        }

		public override Value Execute(params Value[] values)
		{
			return ExecuteBinary(values[0], values[1]);
		}

        public abstract Value ExecuteBinary(Value value1, Value value2);
    }
}
