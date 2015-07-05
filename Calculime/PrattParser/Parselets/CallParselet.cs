using System.Collections.Generic;
using PrattParser.Expressions;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace PrattParser.Parselets
{
    /**
     * Parselet to parse a function call like "a(b, c, d)".
     */
    public class CallParselet : IInfixParselet
    {
        public IExpression Parse(Parser parser, IExpression left, Token token)
        {
            //// Perform Implicit Multiplication if the left expression is not a NameExpression
            //if (!(left is NameExpression))
            //{
            //    var right = parser.ParseExpression();
            //    parser.Consume(TokenType.RightParen);

            //    return new OperatorExpression(left, TokenType.Asterisk, right);
            //}

            // Parse the comma-separated arguments until we hit, ")".
            var args = new List<IExpression>();

            // There may be no arguments at all.
            if (!parser.Match(TokenType.RightParen))
            {
                do
                {
                    args.Add(parser.ParseExpression());
                } while (parser.Match(TokenType.Comma));

                parser.Consume(TokenType.RightParen);
            }

            return new CallExpression(left, args);
        }

        public Precedence GetPrecedence()
        {
            return Precedence.Call;
        }
    }
}
