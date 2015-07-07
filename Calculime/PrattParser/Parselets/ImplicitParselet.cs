using PrattParser.Expressions;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace PrattParser.Parselets
{
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
