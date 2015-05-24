using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.Operations;
using Calculime.DataStructures.Values;
using System.Text.RegularExpressions;

namespace Calculime.DataStructures.Tree
{
    class ExpressionTree<Data>
    {
		private int size;
		private Node<Data> root;

		private ExpressionQueue expressionQueue;
		private OperationStack operationStack;

		public ExpressionTree()
		{
			size = 0;
			root = new Node<Data>();

			expressionQueue = new ExpressionQueue();
			operationStack = new OperationStack();
		}

        public void Build(string infixExpression)
		{
			// Create a regex based on the token operators, and create a list of tokens
			string pattern = "(" + String.Join("|", Token.OPERATORS.Select(d => Regex.Escape(d)).ToArray()) + ")";
			List<string> tokens = Regex.Split(infixExpression, pattern).ToList();

			// Use Shunting Yard Algorithm to generate postfix expression
			foreach (string token in tokens)
			{
				ParseToken(new Token(token));
			}

			while (!operationStack.Empty())
			{
				Token op = new Token(operationStack.Pop());
				expressionQueue.Enqueue(op);
			}
		}

		private void ParseToken(Token token)
		{
			if (token.IsValue)
			{
				expressionQueue.Enqueue(token);
			}
			else
			{
				Operation operation = token.Operation;

				while (!operationStack.Empty() && operation.Precedence <= operationStack.Peek().Precedence)
				{
					Token op = new Token(operationStack.Pop());
					expressionQueue.Enqueue(op);
				}

				operationStack.Push(operation);
			}
		}

		public string Calculate()
		{
			ValueStack stack = new ValueStack();

			while (!expressionQueue.Empty())
			{
				Token token = expressionQueue.Dequeue();

				if (token.IsValue)
				{
					stack.Push(token.Value);
				}
				else if (token.IsOperation)
				{
					Operation operation = token.Operation;

					//if (operation.IsBinary)

					Value value1 = stack.Pop();
					Value value2 = stack.Pop();

					stack.Push(token.Operation.execute(value2, value1));	
				}
				else
				{
					Console.WriteLine("Error: Invalid Token");
				}
			}

			return stack.Pop().ToString();
		}

		// Output Methods
		public string GetPrefix()
		{
			return "";
		}

		public string GetInfix()
		{
			return "";
		}

		public string GetPostfix()
		{
			return "";
		}
    }
}
