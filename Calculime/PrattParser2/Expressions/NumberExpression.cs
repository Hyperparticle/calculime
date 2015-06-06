using System.Text;

namespace PrattParser2.Expressions
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
            _value = double.Parse(name);
        } 

        public string GetName() { return _name; }
        public double GetValue() { return _value; }

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
