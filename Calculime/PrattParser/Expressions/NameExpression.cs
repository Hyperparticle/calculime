﻿using System;
using System.Text;
using PrattParser.Tokens;

namespace PrattParser.Expressions
{
    /**
     * A simple variable name expression like "abc".
     */
    public class NameExpression : IExpression
    {
        private readonly string _name;

        public NameExpression(string name)
        {
            _name = name;
        } 

        public string GetName() { return _name; }

        public double Execute()
        {
            var name = _name.ToLower();
            return Value.StringToValue[name];
        }

        public void Print(StringBuilder builder)
        {
            builder.Append(_name);
        }
    }
}
