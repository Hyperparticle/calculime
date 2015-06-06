using PrattParser2.Expressions;
using PrattParser2.Parsers;
using PrattParser2.Tokens;

namespace PrattParser2.Parselets
{
    /**
     * Simple parselet for a named variable like "abc".
     */
    public class NameParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token)
        {
            return new NameExpression(token.GetText());
        }
    }
}
