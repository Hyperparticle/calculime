using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.UnaryOperations
{
    public abstract class UnaryOperation : Operation
    {
        protected UnaryOperation()
        {
            Precedence = (int)Priority.Highest;
            LeftAssociative = true;
            NumArguments = 1;
        }

		public override Value Execute(params Value[] values)
		{
			return ExecuteUnary(values[0]);
		}

        public abstract Value ExecuteUnary(Value value);
    }
}
