using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Calculime.Operations;

namespace Calculime.DataStructures
{
    /**
     * Wrapper class for a stack
     */
    public class OperationStack
    {
        private Stack<Operation> stack;

        public OperationStack() 
        {
            stack = new Stack<Operation>(); 
        }

        public Operation Pop()
        {
            return stack.Pop();
        }
        public void Push(Operation value)
        {
            stack.Push(value);
        }

        public Operation Peek()
        {
            return stack.Peek();
        }

        public bool Empty()
        {
            return stack.Count == 0;
        }

        public void Clear()
        {
            stack.Clear();
        }
     }
}
