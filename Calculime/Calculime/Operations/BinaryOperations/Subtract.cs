using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculime.Operations.BinaryOperations
{
    public class Subtract : BinaryOperation
    {
        public Subtract()
        {
            precedence = LOW;
            symbol = "-";
        }

        public override Value executeBinary(Value value1, Value value2)
        {
            return value1.subtract(value2);
        }
    }
}
