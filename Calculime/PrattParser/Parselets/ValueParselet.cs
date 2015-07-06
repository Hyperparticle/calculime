using PrattParser.Expressions;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace PrattParser.Parselets
{
    /**
     * Simple parselet for a named variable like "abc".
     */
    public class ValueParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token)
        {
            return new ValueExpression(token.GetText());
        }
    }
}
