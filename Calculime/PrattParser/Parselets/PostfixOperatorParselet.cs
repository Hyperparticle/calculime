using PrattParser.Expressions;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace PrattParser.Parselets
{
    /**
     * Generic infix parselet for an unary arithmetic operator. Parses postfix
     * unary "?" expressions.
     */
    public class PostfixOperatorParselet : IInfixParselet
    {
        private readonly int _precedence;

        public PostfixOperatorParselet(int precedence)
        {
            _precedence = precedence;
        }

        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            return new PostfixExpression(left, token.GetTokenType());
        }

        public int GetPrecedence()
        {
            return _precedence;
        }
    }
}
