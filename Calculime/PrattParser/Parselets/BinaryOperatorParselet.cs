using PrattParser.Expressions;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace PrattParser.Parselets
{
    /**
     * Generic infix parselet for a binary arithmetic operator. The only
     * difference when parsing, "+", "-", "*", "/", and "^" is precedence and
     * associativity, so we can use a single parselet class for all of those.
     */
    public class BinaryOperatorParselet : IInfixParselet
    {
        private readonly Precedence _precedence;
        private readonly bool _isRight;

        public BinaryOperatorParselet(Precedence precedence, bool isRight)
        {
            _precedence = precedence;
            _isRight = isRight;
        }

        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            //if (token.GetTokenType() == TokenType.Number)
            //{
            //    return new OperatorExpression(left, TokenType.Asterisk, parser.ParseExpression());
            //}

            // To handle right-associative operators like "^", we allow a slightly
            // lower precedence when parsing the right-hand side. This will let a
            // parselet with the same precedence appear on the right, which will then
            // take *this* parselet's result as its left-hand argument.
            var right = parser.ParseExpression(_precedence - (_isRight ? 1 : 0));
            return new OperatorExpression(left, token.GetTokenType(), right);
        }

        public Precedence GetPrecedence()
        {
            return _precedence;
        }
    }
}
