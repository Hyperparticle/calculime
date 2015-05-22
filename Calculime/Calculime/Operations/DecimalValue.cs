using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculime.Operations
{
    class DecimalValue : Value
    {
        public static double PERCENT = 0.01;

        protected double value;

        public DecimalValue(string s)
        {
            value = double.Parse(s);
        }

        public DecimalValue(double value)
        {
            this.value = value;
        }

        public Value create(string s)
        {
            return new DecimalValue(s);
        }

        public Value add(Value other)
        {
            double result = value + ((DecimalValue)other).value;
            return new DecimalValue(result);
        }

        public Value subtract(Value other)
        {
            double result = value - ((DecimalValue)other).value;
            return new DecimalValue(result);
        }

        public Value multiply(Value other)
        {
            double result = value * ((DecimalValue)other).value;
            return new DecimalValue(result);
        }

        public Value divide(Value other)
        {
            try
            {
                double result = value / ((DecimalValue)other).value;
                return new DecimalValue(result);
            }
            catch (ArithmeticException e)
            {
                //If dividing by zero, report and leave the current value
                Console.Error.WriteLine("Divide by zero error.");
                return this;
            }
        }

        public Value squareRoot()
        {
            double result = Math.Sqrt(value);
            return new DecimalValue(result);
        }

        public Value inverse()
        {
            try
            {
                double result = 1 / value;
                return new DecimalValue(result);
            }
            catch (ArithmeticException e)
            {
                //If dividing by zero, report and leave the current value
                Console.Error.WriteLine("Divide by zero error.");
                return this;
            }
        }

        public Value negate()
        {
            double result = -value;
            return new DecimalValue(result);
        }

        public Value percent()
        {
            double result = value * PERCENT;
            return new DecimalValue(result);
        }

        public string addDigit(string number, string digit)
        {
            bool isDecimalSet = !(number.IndexOf(".") == -1);

            //Ignore extra decimal points
            if (digit.Equals(".") && isDecimalSet)
            {
                return number;
            }

            //Replace zero
            if (number.Equals("0"))
            {
                return digit;
            }

            //Append digit to number
            return number + digit;
        }

        public override string ToString()
        {
            string s = value.ToString();
            
            //Remove trailing zeroes
            if (s.IndexOf(".") != -1)
            {
                for (int i = s.Length; i > 0; i--)
                {
                    if (!s.ElementAt(i - 1).Equals("0"))
                    {
                        s = s.Substring(0, i);
                        break;
                    }
                }
            }

            return s;
        }
    }
}
