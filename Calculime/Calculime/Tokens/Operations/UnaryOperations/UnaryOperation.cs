using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.UnaryOperations
{
    public abstract class UnaryOperation : Operation
    {
		public override Value Execute(params Value[] values)
		{
			return ExecuteUnary(values[0]);
		}

        public abstract Value ExecuteUnary(Value value);
    }
}
