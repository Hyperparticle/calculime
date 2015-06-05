using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using PrattParser.Expressions;
using PrattParser.Parselets;

namespace PrattParser
{
    public class Parser
    {
        private readonly IEnumerator<Token> _tokens;
        private readonly List<Token> _read = new List<Token>();

        private readonly Dictionary<TokenType, IPrefixParselet> _dPrefixParselets =
            new Dictionary<TokenType, IPrefixParselet>();
        private readonly Dictionary<TokenType, IInfixParselet> _dInfixParselets =
            new Dictionary<TokenType, IInfixParselet>();

        public Parser(IEnumerator<Token> tokens)
        {
            _tokens = tokens;
        }

        public void Register(TokenType token, IPrefixParselet parselet)
        {
            _dPrefixParselets[token] = parselet;
        }

        public void Register(TokenType token, IInfixParselet parselet)
        {
            _dInfixParselets[token] = parselet;
        }

        public IExpression ParseExpression(int precedence = 0)
        {
            Token token = Consume();
            IPrefixParselet prefix;
            if (!_dPrefixParselets.TryGetValue(token.GetTokenType(), out prefix))
                throw new ParseException("Could not parse \'" + token.GetText() + "\'.");
            
            var left = prefix.Parse(this, token);

            while (precedence < GetPrecedence())
            {
                token = Consume();

                var infix = _dInfixParselets[token.GetTokenType()];
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
            Token token = LookAhead(0);
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
                _read.Add((Token)_tokens.Current);
            }

            // Get the queued token.
            return _read[distance];
        }

        private int GetPrecedence()
        {
            IInfixParselet parser;
            if (!_dInfixParselets.TryGetValue(LookAhead(0).GetTokenType(), out parser))
                return 0;

            return parser.GetPrecedence();
        }
    }
}
