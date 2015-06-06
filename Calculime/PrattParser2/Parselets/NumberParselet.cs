using PrattParser2.Expressions;
using PrattParser2.Parsers;
using PrattParser2.Tokens;

namespace PrattParser2.Parselets
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
