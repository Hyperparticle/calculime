using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.Operations;

namespace Calculime.DataStructures.Tree
{
	/**
     * Wrapper class for a stack
     */
	public class OperationStack
	{
		private Stack<Token> stack;

		public OperationStack()
		{
            stack = new Stack<Token>();
		}

        public Token Pop()
		{
			return stack.Pop();
		}
        public void Push(Token value)
		{
			stack.Push(value);
		}

        public Token Peek()
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
