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
        private string token;

        public Token(string tok)
        {
            token = tok;
            EvaluateToken();
        }

        private void EvaluateToken()
        {
            double val;
            if (double.TryParse(token, out val))
            {
                Value = new DecimalValue(val);
                Type = Value.GetType();

                IsValue = true;
                IsOperation = false;
            }
            else
            {
                Operation = ParseOperation();
                Type = Operation.GetType();

                IsValue = false;
                IsOperation = true;
            }
        }

        private Operation ParseOperation()
        {
            switch (token)
            {
                case "+": return new Add();
                case "-": return new Subtract();
                default: Console.WriteLine("Error: Invalid Operator."); return null;
            }
        }

        public Value Value { get; set; }
        public Operation Operation { get; set; }

        public bool IsValue { get; set; }
        public bool IsOperation { get; set; }

        public Type Type { get; set; }
    }
}
