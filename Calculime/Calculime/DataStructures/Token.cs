using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures.Values;
using Calculime.Operations;
using Calculime.Operations.BinaryOperations;

namespace Calculime.DataStructures
{
    public class Token
    {
		public static string[] OPERATORS = { "+", "-", "*", "/", "^", "%" };

        private string token;

		// Use this dictionary to map string operators to their respective functions
		public static Dictionary<string, Operation> operationDict = new Dictionary<string, Operation>()
		{
			{ "+", new Add() },
			{ "-", new Subtract() },
			{ "*", new Multiply() },
			{ "/", new Divide() },
			{ "^", new Power() },
			{ "%", new Modulo() }
		};

        public Token(string tok)
        {
            token = tok;
            EvaluateToken();
        }

		public Token(Value value)
		{
			token = value.ToString();
			Value = value;

			IsValue = true;
			IsOperation = false;
		}

		public Token(Operation operation)
		{
			token = operation.ToString();
			Operation = operation;

			IsValue = false;
			IsOperation = true;
		}

        private void EvaluateToken()
        {
            double val;
            if (double.TryParse(token, out val))
            {
                Value = new DecimalValue(val);

                IsValue = true;
                IsOperation = false;
            }
            else
            {
				Operation op;
				operationDict.TryGetValue(token, out op);
				Operation = op;

                IsValue = false;
                IsOperation = true;
            }
        }

        public Value Value { get; protected set; }
        public Operation Operation { get; protected set; }

        public bool IsValue { get; protected set; }
        public bool IsOperation { get; protected set; }
    }
}
