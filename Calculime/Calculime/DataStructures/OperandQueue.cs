using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculime.DataStructures
{
    /**
     * Wrapper class for a queue
     */
    public class ExpressionQueue
    {
        private Queue<Token> queue;

        public ExpressionQueue() 
        {
            queue = new Queue<Token>(); 
        }

        public Token Dequeue()
        {
            return queue.Dequeue();
        }

        public void Enqueue(Token token)
        {
            queue.Enqueue(token);
        }

        public Token Peek()
        {
            return queue.Peek();
        }

        public bool Empty()
        {
            return queue.Count == 0;
        }

        public void Clear()
        {
            queue.Clear();
        }
     }
}
