using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculime.Operations
{
    /**
     * Wrapper class for a stack
     */
    public class OperandStack
    {
        private Stack<Value> stack;

        public OperandStack() 
        { 
          stack = new Stack<Value>(); 
        }

        public Value pop()
        {
            return stack.Pop();
        }
        public void push(Value value)
        {
            stack.Push(value);
        }

        public Value peek()
        {
            return (Value)stack.Peek();
        }

        public bool empty()
        {
            return stack.Count == 0;
        }

        public void clear()
        {
            stack.Clear();
        }
     }
}
