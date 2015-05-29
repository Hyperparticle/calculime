﻿using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations.BinaryOperations
{
    public class Multiply : BinaryOperation
    {
        public Multiply()
        {
            Symbol = "*";
			Precedence = (int)Priority.Medium;
			LeftAssociative = true;
        }

        public override Value ExecuteBinary(Value value1, Value value2)
        {
            return value1 * value2;
        }
    }
}
