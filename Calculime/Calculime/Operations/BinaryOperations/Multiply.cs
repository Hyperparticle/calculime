using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculime.Operations.BinaryOperations
{
    public class Multiply : BinaryOperation
    {
        public Multiply()
        {
            precedence = LOW;
            symbol = "*";
        }

        public override Value executeBinary(Value value1, Value value2)
        {
            return value1.multiply(value2);
        }
    }
}
