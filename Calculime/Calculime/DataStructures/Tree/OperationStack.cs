using System.Collections.Generic;
using Calculime.Tokens;

namespace Calculime.DataStructures.Tree
{
	/**
     * Wrapper class for a stack
     */
	public class OperationStack
	{
		private readonly Stack<Token> _stack;

		public OperationStack()
		{
            _stack = new Stack<Token>();
		}

        public Token Pop()
		{
			return _stack.Pop();
		}
        public void Push(Token value)
		{
			_stack.Push(value);
		}

        public Token Peek()
		{
			return _stack.Peek();
		}

        public int Count()
        {
            return _stack.Count;
        }

		public bool Empty()
		{
			return _stack.Count == 0;
		}

		public void Clear()
		{
			_stack.Clear();
		}
	}
}
