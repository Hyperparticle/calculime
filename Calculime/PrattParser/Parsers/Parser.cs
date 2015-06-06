using System;
using System.Collections.Generic;
using PrattParser.Expressions;
using PrattParser.Parselets;
using PrattParser.Tokens;

namespace PrattParser.Parsers
{
    public class Parser
    {
        private readonly IEnumerator<Token> _tokens;
        private readonly List<Token> _read = new List<Token>();

        private readonly Dictionary<TokenType, IPrefixParselet> _prefixParselets =
            new Dictionary<TokenType, IPrefixParselet>();
        private readonly Dictionary<TokenType, IInfixParselet> _infixParselets =
            new Dictionary<TokenType, IInfixParselet>();

        public Parser(IEnumerator<Token> tokens)
        {
            _tokens = tokens;
        }

        public void Register(TokenType token, IPrefixParselet parselet)
        {
            _prefixParselets[token] = parselet;
        }

        public void Register(TokenType token, IInfixParselet parselet)
        {
            _infixParselets[token] = parselet;
        }

        public IExpression ParseExpression(Precedence precedence = 0)
        {
            var token = Consume();

            IPrefixParselet prefix;
            if (!_prefixParselets.TryGetValue(token.GetTokenType(), out prefix))
                throw new ParseException("Could not parse \'" + token.GetText() + "\'.");
            
            var left = prefix.Parse(this, token);

            while (precedence < GetPrecedence())
            {
                token = Consume();

                var infix = _infixParselets[token.GetTokenType()];
                left = infix.Parse(this, left, token);
            }

            return left;
        }

        public bool Match(TokenType expected)
        {
            var token = LookAhead(0);
            if (token.GetTokenType() != expected)
                return false;

            Consume();
            return true;
        }

        public Token Consume(TokenType expected)
        {
            var token = LookAhead(0);
            if (token.GetTokenType() != expected)
                throw new Exception("Expected token \'" + expected + 
                    "\' and found \'" + token.GetTokenType() + " \'");

            return Consume();
        }

        public Token Consume()
        {
            // Make sure we've read the token.
            LookAhead(0);

            var next = _read[0];
            _read.RemoveAt(0);

            return next;
        }

        private Token LookAhead(int distance)
        {
            // Read in as many as needed.
            while (distance >= _read.Count)
            {
                _tokens.MoveNext();
                _read.Add(_tokens.Current);
            }

            // Get the queued token.
            return _read[distance];
        }

        private Precedence GetPrecedence()
        {
            IInfixParselet parser;
            if (!_infixParselets.TryGetValue(LookAhead(0).GetTokenType(), out parser))
                return 0;

            return parser.GetPrecedence();
        }
    }
}
