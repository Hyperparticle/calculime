using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.Operations.BinaryOperations
{
    public abstract class BinaryOperation : Operation
    {
		public override Value execute(params Value[] values)
		{
			return executeBinary(values[0], values[1]);
		}

        public abstract Value executeBinary(Value value1, Value value2);
    }
}
