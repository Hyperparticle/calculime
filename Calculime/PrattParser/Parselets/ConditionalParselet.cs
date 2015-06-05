using PrattParser.Expressions;

namespace PrattParser.Parselets
{
    /**
     * Parselet for the condition or "ternary" operator, like "a ? b : c".
     */
    public class ConditionalParselet : IInfixParselet
    {
        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            var thenArm = parser.ParseExpression();
            parser.Consume(TokenType.Colon);
            var elseArm = parser.ParseExpression();

            return new ConditionalExpression(left, thenArm, elseArm);
        }

        public int GetPrecedence()
        {
            return (int)Precedence.Conditional;
        }
    }
}
