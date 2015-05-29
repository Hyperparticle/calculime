using System.Collections.Generic;
using Calculime.DataStructures.Values;
using Calculime.Exceptions;
using Calculime.Tokens.Operations;
using Calculime.Tokens.Operations.BinaryOperations;
using Calculime.Tokens.Separators;

namespace Calculime.Tokens
{
    public class Token
    {
		public static string[] Operators = { "+", "-", "*", "/", "^", "%", "(", ")", "," };

        private readonly string _token;

		// Use these dictionaries to map string operators to their respective functions
		public static Dictionary<string, Operation> OperationDict = new Dictionary<string, Operation>()
		{
			{ "+", new Add() },
			{ "-", new Subtract() },
			{ "*", new Multiply() },
			{ "/", new Divide() },
			{ "^", new Power() },
			{ "%", new Modulo() }
		};

        public static Dictionary<string, Separator> SeparatorDict = new Dictionary<string, Separator>()
		{
			{ "(", new LeftParenthesis() },
			{ ")", new RightParenthesis() },
			{ ",", new Comma() }
		};

        // Constructors
        public Token(string tok)
        {
            _token = tok;
            EvaluateToken();
        }

		public Token(Value value)
		{
			_token = value.ToString();
			Value = value;

			IsValue = true;
			IsOperation = false;
		}

		public Token(Operation operation)
		{
			_token = operation.ToString();
			Operation = operation;

			IsValue = false;
			IsOperation = true;
		}

        // Parses for the correct token identifier
        private void EvaluateToken()
        {
            double val;
            Operation op;
            Separator sep;

            if (double.TryParse(_token, out val))
            {
                Value = new DecimalValue(val);
                IsValue = true;
            }
            else if (OperationDict.TryGetValue(_token, out op))
            {
                Operation = op;
                IsOperation = true;
            }
            else if (SeparatorDict.TryGetValue(_token, out sep))
            {
                Separator = sep;
                IsSeparator = true;
            }
            else
            {
                throw new InvalidTokenException();
            }
        }

        // Identifiers
        public Value Value { get; protected set; }
        public Operation Operation { get; protected set; }
        public Separator Separator { get; protected set; }

        public bool IsValue { get; protected set; }
        public bool IsOperation { get; protected set; }
        public bool IsSeparator { get; protected set; }
    }
}
