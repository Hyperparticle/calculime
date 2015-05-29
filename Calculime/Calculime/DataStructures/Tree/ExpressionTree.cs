using System;
using System.Linq;
using System.Text.RegularExpressions;
using Calculime.Exceptions;
using Calculime.Tokens;

namespace Calculime.DataStructures.Tree
{
    class ExpressionTree<TData>
    {
		private int _size;
		private Node<TData> _root;

		private readonly ExpressionQueue _expressionQueue;
		private readonly OperationStack _operationStack;

		public ExpressionTree()
		{
			_size = 0;
			_root = new Node<TData>();

			_expressionQueue = new ExpressionQueue();
			_operationStack = new OperationStack();
		}

        public void Build(string infixExpression)
		{
            _expressionQueue.Clear();
            _operationStack.Clear();

			// Create a regex based on the token operators, and create a list of tokens
			var pattern = "(" + String.Join("|", Token.Operators.Select(Regex.Escape).ToArray()) + ")";
			var tokens = Regex.Split(infixExpression, pattern).Where(s => !string.IsNullOrWhiteSpace(s)).ToList();

			// Use Shunting Yard Algorithm to generate a postfix expression
			foreach (var token in tokens)
			{
			    ParseToken(new Token(token));
			}

			while (!_operationStack.Empty())
			{
				var op = _operationStack.Pop();
                if (op.IsSeparator) throw new MismatchedParenthesisException();
				_expressionQueue.Enqueue(op);
			}
		}

		private void ParseToken(Token token)
		{
			if (token.IsValue)
			{
				_expressionQueue.Enqueue(token);
			}
			else if (token.IsOperation)
			{
                var operation = token.Operation;

                if (!_operationStack.Empty() && _operationStack.Peek().IsOperation)
                {
				    while (!_operationStack.Empty())
				    {
                        if (operation.LeftAssociative && operation.Precedence <= _operationStack.Peek().Operation.Precedence ||
                            !operation.LeftAssociative && operation.Precedence < _operationStack.Peek().Operation.Precedence)
					    {
                            _expressionQueue.Enqueue(_operationStack.Pop());
					    }
					    else break;
				    }
                }

                _operationStack.Push(token);
			}
            else if (token.IsSeparator)
            {
                var separator = token.Separator;

                if (separator.Symbol.Equals("("))
                {
                    _operationStack.Push(token);
                }
                else if (separator.Symbol.Equals(")"))
                {
                    if (_operationStack.Empty()) throw new MismatchedParenthesisException();

                    while (!(_operationStack.Peek().IsSeparator && _operationStack.Peek().Separator.Symbol.Equals("(")))
                    {
                        if (_operationStack.Empty()) throw new MismatchedParenthesisException();
                        _expressionQueue.Enqueue(_operationStack.Pop());
                    }

                    // Pop the left parenthesis
                    _operationStack.Pop();
                }
            }
		}

		public string Calculate()
		{
			var stack = new ValueStack();

			while (!_expressionQueue.Empty())
			{
				var token = _expressionQueue.Dequeue();

				if (token.IsValue)
				{
					stack.Push(token.Value);
				}
				else if (token.IsOperation)
				{
					var operation = token.Operation;

					//if (operation.IsBinary)

					var value1 = stack.Pop();
					var value2 = stack.Pop();

					stack.Push(token.Operation.Execute(value2, value1));	
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
