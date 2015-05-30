using System.Collections.Generic;
using Calculime.Tokens;

namespace Calculime.DataStructures.Tree
{
	/**
     * Wrapper class for a queue
     */
	class ExpressionQueue
	{
        private readonly Queue<Token> _queue;

        public ExpressionQueue() 
        {
            _queue = new Queue<Token>(); 
        }

        public Token Dequeue()
        {
            return _queue.Dequeue();
        }

        public void Enqueue(Token token)
        {
            _queue.Enqueue(token);
        }

        public Token Peek()
        {
            return _queue.Peek();
        }

        public int Count()
        {
            return _queue.Count;
        }

        public bool Empty()
        {
            return _queue.Count == 0;
        }

        public void Clear()
        {
            _queue.Clear();
        }
	}
}
