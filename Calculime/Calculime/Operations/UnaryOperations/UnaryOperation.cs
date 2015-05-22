using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculime.Operations.UnaryOperations
{
    public abstract class UnaryOperation : Operation
    {
        public UnaryOperation()
        {
            precedence = HIGH;
        }

        public override void execute()
        {
            //Exchange old value for new
            stack.push(executeUnary(stack.pop()));
        }

        public abstract Value executeUnary(Value value);
    }
}
