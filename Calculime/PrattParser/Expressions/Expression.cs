using System.Text;

namespace PrattParser.Expressions
{
    /// <summary>
    /// Wrapper class for an IExpression, with additional functionality.
    /// </summary>
    public class Expression : IExpression
    {
        public Expression(string userExpression, IExpression expression)
        {
            UserExpression = userExpression;
            TokenExpression = expression;
        }

        public double Calculate()
        {
            return TokenExpression.Calculate();
        }

        public void Print(StringBuilder builder)
        {
            TokenExpression.Print(builder);
        }

        public string UserExpression { get; protected set; }
        public IExpression TokenExpression { get; protected set; }
    }
}
