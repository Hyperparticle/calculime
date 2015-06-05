using PrattParser.Expressions;

namespace PrattParser.Parselets
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
