using System;
using System.Collections.Generic;
using PrattParser.Exceptions;
using PrattParser.Expressions;
using PrattParser.Parselets;
using PrattParser.Tokens;

namespace PrattParser.Parsers
{
    /// <summary>
    /// A Recursive Descent Pratt Parser.
    /// Responsible for parsing string expressions.
    /// </summary>
    public class Parser
    {
        private IEnumerator<Token> _tokens;     // Will iterate through the string expression
        private List<Token> _read;              // A queue to read in characters

        private readonly Dictionary<TokenType, IPrefixParselet> _prefixParselets =
            new Dictionary<TokenType, IPrefixParselet>();
        private readonly Dictionary<TokenType, IInfixParselet> _infixParselets =
            new Dictionary<TokenType, IInfixParselet>();

        public void Register(TokenType token, IPrefixParselet parselet)
        {
            _prefixParselets[token] = parselet;
        }

        public void Register(TokenType token, IInfixParselet parselet)
        {
            _infixParselets[token] = parselet;
        }

        public IExpression ParseExpression(string expression)
        {
            _tokens = new Lexer(expression);
            _read = new List<Token>();
            return ParseExpression();
        }

        public IExpression ParseExpression(Precedence precedence = 0)
        {
            if (_tokens == null) return null;

            var token = Consume();

            IPrefixParselet prefix;
            if (!_prefixParselets.TryGetValue(token.GetTokenType(), out prefix))
                throw new ParseException("Could not parse \'" + token.GetText() + "\'.");
            
            var left = prefix.Parse(this, token);

            // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            // An enumerator is used, so precedence will change based on current position
            while (precedence < GetPrecedence(token))
            {
                token = Consume();

                var infix = _infixParselets[token.GetTokenType()];

                left = infix.Parse(this, left, token);
            }

            var next = LookAhead().GetTokenType();
            // If the token is not empty, perform implicit multiplication
            if (next != TokenType.Eof && next != TokenType.RightParen)
            {
                var infix = _infixParselets[TokenType.Asterisk];
                left = infix.Parse(this, left, Token.Product());
            }

            return left;
        }

        public double Execute(string expression)
        {
            return ParseExpression(expression).Execute();
        }

        public bool Match(TokenType expected)
        {
            var token = LookAhead();
            if (token.GetTokenType() != expected)
                return false;

            Consume();
            return true;
        }

        public Token Consume(TokenType expected)
        {
            var token = LookAhead();
            if (token.GetTokenType() != expected)
                throw new Exception("Expected token \'" + expected + 
                    "\' and found \'" + token.GetTokenType() + " \'");

            return Consume();
        }

        public Token Consume()
        {
            // Make sure we've read the token.
            LookAhead();

            var next = _read[0];
            _read.RemoveAt(0);

            return next;
        }

        private Token LookAhead(int distance = 0)
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

        private Precedence GetPrecedence(Token prevToken)
        {
            IInfixParselet parselet;
            var type = LookAhead().GetTokenType();

            if (type == TokenType.LeftParen && Value.StringToConstant.ContainsKey(prevToken.GetText()))
                return 0;
            
            return (_infixParselets.TryGetValue(type, out parselet))
                ? parselet.GetPrecedence() : 0;
        }
    }
}
