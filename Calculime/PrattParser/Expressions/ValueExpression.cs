using System.Text;
using PrattParser.Tokens;

namespace PrattParser.Expressions
{
    /**
     * A simple variable value expression like "pi".
     */
    public class ValueExpression : IExpression
    {
        private readonly string _name;
        private readonly double _value;

        public ValueExpression(string name)
        {
            _name = name;

            _value = Value.GetValue(name.ToLower());
        } 

        public string GetName() { return _name; }

        public double Execute()
        {
            return _value;
        }

        public void Print(StringBuilder builder)
        {
            builder.Append(_name);
        }
    }
}
