using PrattParser.Expressions;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace PrattParser.Parselets
{
    /**
     * Generic prefix parselet for an unary arithmetic operator. Parses prefix
     * unary "-", "+", "~", and "!" expressions.
     */
    public class PrefixOperatorParselet : IPrefixParselet
    {
        private readonly int _precedence;

        public PrefixOperatorParselet(int precedence)
        {
            _precedence = precedence;
        }

        public IExpression Parse(Parser parser, Token token)
        {
            // To handle right-associative operators like "^", we allow a slightly
            // lower precedence when parsing the right-hand side. This will let a
            // parselet with the same precedence appear on the right, which will then
            // take *this* parselet's result as its left-hand argument.
            var right = parser.ParseExpression(_precedence);

            return new PrefixExpression(token.GetTokenType(), right);
        }

        public int GetPrecedence() {
            return _precedence;
        }
    }
}
