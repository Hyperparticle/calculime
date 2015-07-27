using System;
using System.Collections.Generic;
using System.Text;

namespace PrattParser.Expressions
{
    /**
     * A simple variable name expression like "abc".
     */
    public class NumberExpression : IExpression
    {
        private readonly string _name;
        private readonly double _value;

        public NumberExpression(string name)
        {
            _name = name;

            // Special characters change number's base
            if (name.Length >= 2)
            {
                var prefix = name.Substring(0, 2);

                switch (prefix)
                {
                    case "0x":
                        _value = Convert.ToInt64(name, 16);
                        return;
                    case "0b":
                        _value = Convert.ToInt64(name.Substring(2, name.Length-2), 2);
                        return;
                }
            }

            _value = double.Parse(name);
        }

        public string GetName() { return _name; }
        public double GetValue() { return _value; }

        public double Calculate()
        {
            return _value;
        }

        public void Print(StringBuilder builder)
        {
            builder.Append(_name);
        }
    }
}
