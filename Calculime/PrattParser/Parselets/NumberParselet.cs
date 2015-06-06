using PrattParser.Expressions;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace PrattParser.Parselets
{
    /**
     * Simple parselet for a number like "12.05".
     */
    public class NumberParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token)
        {
            return new NumberExpression(token.GetText());
        }
    }
}
