using PrattParser2.Expressions;
using PrattParser2.Parsers;
using PrattParser2.Tokens;

namespace PrattParser2.Parselets
{
    /**
     * Generic infix parselet for an unary arithmetic operator. Parses postfix
     * unary "?" expressions.
     */
    public class PostfixOperatorParselet : IInfixParselet
    {
        private readonly Precedence _precedence;

        public PostfixOperatorParselet(Precedence precedence)
        {
            _precedence = precedence;
        }

        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            return new PostfixExpression(left, token.GetTokenType());
        }

        public Precedence GetPrecedence()
        {
            return _precedence;
        }
    }
}
