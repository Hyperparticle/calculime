using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculime.Operations.BinaryOperations
{
    public abstract class BinaryOperation : Operation
    {
        public BinaryOperation()
        {

        }

        public override void execute()
        {
            Value value1, value2;
            value2 = stack.pop();
            value1 = stack.pop();
            stack.push(executeBinary(value1, value2));
        }

        public abstract Value executeBinary(Value value1, Value value2);
    }
}
