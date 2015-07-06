using System;
using System.Collections.Generic;
using PrattParser.Exceptions;
using PrattParser.Expressions;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace PrattParser.Parselets
{
    public class FunctionParselet : IPrefixParselet
    {
        public IExpression Parse(Parser parser, Token token)
        {
            if (!parser.Match(TokenType.LeftParen))
                throw new ParseException("Function must be proceeded by parentheses.");

            var args = new List<IExpression>();

            // There may be no arguments at all.
            if (parser.Match(TokenType.RightParen)) 
                return new FunctionExpression(token.GetText(), args);

            // Parse the comma-separated arguments until we hit, ")".
            do
            {
                args.Add(parser.ParseExpression());
            } while (parser.Match(TokenType.Comma));

            parser.Consume(TokenType.RightParen);

            return new FunctionExpression(token.GetText(), args);
        }

        public Precedence GetPrecedence()
        {
            return Precedence.Call;
        }
    }
}
