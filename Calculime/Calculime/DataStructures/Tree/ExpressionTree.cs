using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.Operations;
using Calculime.DataStructures.Values;
using System.Text.RegularExpressions;
using Calculime.Exceptions;

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
			List<string> tokens = Regex.Split(infixExpression, pattern).Where(s => !string.IsNullOrEmpty(s)).ToList();

			// Use Shunting Yard Algorithm to generate a postfix expression
			foreach (string token in tokens)
			{
                if (!string.IsNullOrEmpty(token))
				    ParseToken(new Token(token));
			}

			while (!operationStack.Empty())
			{
				Token op = operationStack.Pop();
                if (op.IsSeparator) throw new MismatchedParenthesisException();
				expressionQueue.Enqueue(op);
			}
		}

		private void ParseToken(Token token)
		{
			if (token.IsValue)
			{
				expressionQueue.Enqueue(token);
			}
			else if (token.IsOperation)
			{
                Operation operation = token.Operation;

                if (!operationStack.Empty() && operationStack.Peek().IsOperation)
                {
                   Operation stackOperation = operationStack.Peek().Operation;

				    while (!operationStack.Empty())
				    {
					    if (operation.LeftAssociative && operation.Precedence <= stackOperation.Precedence ||
						    !operation.LeftAssociative && operation.Precedence < stackOperation.Precedence)
					    {
                            expressionQueue.Enqueue(operationStack.Pop());
					    }
					    else break;
				    }
                }

                operationStack.Push(token);
			}
            else if (token.IsSeparator)
            {
                Separator separator = token.Separator;

                if (separator.Symbol.Equals("("))
                {
                    operationStack.Push(token);
                }
                else if (separator.Symbol.Equals(")"))
                {
                    if (operationStack.Empty()) throw new MismatchedParenthesisException();

                    while (!(operationStack.Peek().IsSeparator && operationStack.Peek().Separator.Symbol.Equals("(")))
                    {
                        if (operationStack.Empty()) throw new MismatchedParenthesisException();
                        expressionQueue.Enqueue(operationStack.Pop());
                    }

                    // Pop the left parenthesis
                    operationStack.Pop();
                }
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
