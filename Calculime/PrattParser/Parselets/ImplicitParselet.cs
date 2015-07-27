using PrattParser.Expressions;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace PrattParser.Parselets
{
    /// <summary>
    /// A parselet for parsing implicit operations, i.e. multiplication, like 2pi.
    /// Can be configured for other types of operations.
    /// </summary>
    public class ImplicitParselet : IInfixParselet
    {
        private const Precedence ImplicitPrecedence = Precedence.Product;
        private const TokenType ImplicitType = TokenType.Asterisk;

        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            var right = parser.ParseExpression(ImplicitPrecedence);
            return new OperatorExpression(left, ImplicitType, right);
        }

        public Precedence GetPrecedence()
        {
            return ImplicitPrecedence;
        }
    }
}
