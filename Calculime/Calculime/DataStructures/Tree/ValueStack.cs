using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;

namespace Calculime.DataStructures.Tree
{
	/**
     * Wrapper class for a stack
     */
	public class ValueStack
	{
		private Stack<Value> stack;

		public ValueStack()
		{
			stack = new Stack<Value>();
		}

		public Value Pop()
		{
			return stack.Pop();
		}
		public void Push(Value value)
		{
			stack.Push(value);
		}

		public Value Peek()
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
