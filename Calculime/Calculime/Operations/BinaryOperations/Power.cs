using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.Operations.BinaryOperations
{
    public class Power : BinaryOperation
    {
		public Power()
        {
            Symbol = "^";
			Precedence = (int)Operation.Priority.high;
			LeftAssociative = false;
        }

        public override Value executeBinary(Value value1, Value value2)
        {
            return value1 ^ value2;
        }
    }
}
