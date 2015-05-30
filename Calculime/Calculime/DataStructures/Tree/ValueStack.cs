using System.Collections.Generic;
using Calculime.DataStructures.Values;

namespace Calculime.DataStructures.Tree
{
	/**
     * Wrapper class for a stack
     */
	public class ValueStack
	{
		private readonly Stack<Value> _stack;

		public ValueStack()
		{
			_stack = new Stack<Value>();
		}

		public Value Pop()
		{
			return _stack.Pop();
		}
		public void Push(Value value)
		{
			_stack.Push(value);
		}

		public Value Peek()
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
