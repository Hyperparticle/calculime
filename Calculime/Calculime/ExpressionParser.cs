using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures;
using Calculime.DataStructures.Values;
using Calculime.Operations;
using Calculime.Operations.BinaryOperations;

namespace Calculime
{
    /**
     * Responsible for parsing string expressions and returning
     * the result
     */
    class ExpressionParser
    {
        ExpressionQueue outputQueue;
        OperationStack operationStack;

        public ExpressionParser()
        {
            outputQueue = new ExpressionQueue();
            operationStack = new OperationStack();
        }

        public void Parse(string expression)
        {
            List<string> tokens = expression.Split(' ').ToList();

            for (int i = 0; i < tokens.Count; i++)
            {
                ParseToken(new Token(tokens.ElementAt(i)));
            }
        }

        private void ParseToken(Token token)
        {
            if (token.IsValue)
            {
                outputQueue.Enqueue(token);
            }
            else if (token.IsOperation)
            {
                Operation op = token.Operation;

                while (!operationStack.Empty() && op.Precedence <= operationStack.Peek().Precedence)
                {
                    outputQueue.Enqueue(new Token(operationStack.Pop().ToString()));
                }

                operationStack.Push(op);
            }
        }

        public double Evaluate()
        {
            Value result;

            while (!outputQueue.Empty())
            {
                
            }

            return 0;
        }
    }
}
