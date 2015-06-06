﻿using System;

namespace Calculime.Tokens.Values
{
    public abstract class Value
    {
		public abstract double Val { get; set; }

		// Value Operators
		public static Value operator +(Value value1, Value value2)
		{
			value1.Val += value2.Val;
			return value1;
		}

		public static Value operator -(Value value1, Value value2)
		{
			value1.Val -= value2.Val;
			return value1;
		}

		public static Value operator -(Value value)
		{
			value.Val = -value.Val;
			return value;
		}

		public static Value operator *(Value value1, Value value2)
		{
			value1.Val *= value2.Val;
			return value1;
		}

		public static Value operator /(Value value1, Value value2)
		{
			try
			{
				value1.Val /= value2.Val;
			}
			catch (ArithmeticException e)
			{
				Console.WriteLine(e.StackTrace);
			}
			
			return value1;
		}

		public static Value operator %(Value value1, Value value2)
		{
			value1.Val %= value2.Val;
			return value1;
		}

		public static Value operator ^(Value value1, Value value2)
		{
			value1.Val = Math.Pow(value1.Val, value2.Val);
			return value1;
		}
    }
}