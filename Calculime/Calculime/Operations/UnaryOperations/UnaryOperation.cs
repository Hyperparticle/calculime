using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.Operations.UnaryOperations
{
    public abstract class UnaryOperation : Operation
    {
		public override Value execute(params Value[] values)
		{
			return executeUnary(values[0]);
		}

        public abstract Value executeUnary(Value value);
    }
}
