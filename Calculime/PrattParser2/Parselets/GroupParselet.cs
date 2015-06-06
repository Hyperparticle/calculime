using PrattParser2.Expressions;
using PrattParser2.Parsers;
using PrattParser2.Tokens;

namespace PrattParser2.Parselets
{
    /**
     * Parses parentheses used to group an expression, like "a * (b + c)".
     */
    public class GroupParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token)
        {
            var expression = parser.ParseExpression();
            parser.Consume(TokenType.RightParen);
            return expression;
        }
    }
}
