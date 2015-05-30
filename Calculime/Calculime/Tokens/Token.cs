using System.Collections.Generic;
using Calculime.DataStructures.Values;
using Calculime.Exceptions;
using Calculime.Tokens.Operations;
using Calculime.Tokens.Operations.BinaryOperations;
using Calculime.Tokens.Operations.UnaryOperations;
using Calculime.Tokens.Operations.UnaryOperations.Exp;
using Calculime.Tokens.Operations.UnaryOperations.Trig;
using Calculime.Tokens.Separators;

namespace Calculime.Tokens
{
    public class Token
    {
        public static readonly string Add = "+";
        public static readonly string Subtract = "-";
        public static readonly string Multiply = "*";
        public static readonly string Divide = "/";
        public static readonly string Power = "^";
        public static readonly string Modulo = "%";
        public static readonly string LeftParenthesis = "(";
        public static readonly string RightParenthesis = ")";
        public static readonly string Comma = ",";
        public static readonly string Factorial = "!";
        public static readonly string SquareRoot = "sqrt";
        public static readonly string Sine = "sin";
        public static readonly string Cosine = "cos";
        public static readonly string Tangent = "tan";
        public static readonly string Arcsine = "asin";
        public static readonly string Arccosine = "acos";
        public static readonly string Arctangent = "atan";
        public static readonly string Log10 = "log10";
        public static readonly string NaturalLog = "ln";


		public static string[] Operators = { Add, Subtract, Multiply, Divide, Power, Modulo, LeftParenthesis, 
                                               RightParenthesis, Comma, Factorial, SquareRoot, Sine, Cosine,
                                               Tangent, Arcsine, Arccosine, Arctangent, Log10, NaturalLog };

        private readonly string _token;

		// Use these dictionaries to map string operators to their respective functions
		public static Dictionary<string, Operation> OperationDict = new Dictionary<string, Operation>()
		{
			{ Add, new Add() },
			{ Subtract, new Subtract() },
			{ Multiply, new Multiply() },
			{ Divide, new Divide() },
			{ Power, new Power() },
			{ Modulo, new Modulo() },
            { Factorial, new Factorial() },
            { SquareRoot, new SquareRoot() },
            { Sine, new Sine() },
            { Cosine, new Cosine() },
            { Tangent, new Tangent() },
            { Arcsine, new Arcsine() },
            { Arccosine, new Arccosine() },
            { Arctangent, new Arctangent() },
            { Log10, new Log10() },
            { NaturalLog, new NaturalLog() }
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
            _token = tok.ToLower().Trim();
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
