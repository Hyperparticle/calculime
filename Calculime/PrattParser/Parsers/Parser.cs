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
        //private IEnumerator<Token> _tokens;     // Will iterate through the string expression
        //private List<Token> _read;              // A queue to read in characters
        private List<Token> _tokenList; 
        private int _index;

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
            var lexer = new MathLexer(expression);
            _tokenList = lexer.GetTokens();
            _index = 0;
            return ParseExpression();
        }

        public IExpression ParseExpression(Precedence precedence = 0)
        {
            var token = NextToken();

            IPrefixParselet prefix;
            if (!_prefixParselets.TryGetValue(token.GetTokenType(), out prefix))
                throw new ParseException("Could not parse \'" + token.GetText() + "\'.");
            
            var left = prefix.Parse(this, token);

            // ReSharper disable once LoopVariableIsNeverChangedInsideLoop
            // An enumerator is used, so precedence will change based on current position
            while (precedence < GetPrecedence())
            {
                token = LookAhead();

                var infix = _infixParselets[token.GetTokenType()];
                if (!(infix is ImplicitParselet)) NextToken();      // Make sure we don't read the next token if implicit
                
                left = infix.Parse(this, left, token);
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

            NextToken();
            return true;
        }

        public Token Consume(TokenType expected)
        {
            var token = LookAhead();
            if (token.GetTokenType() != expected)
                throw new Exception("Expected token \'" + expected + 
                    "\' and found \'" + token.GetTokenType() + " \'");

            return NextToken();
        }

        public Token NextToken()
        {
            return _tokenList[_index++];
        }

        public Token Revert()
        {
            return _tokenList[--_index];
        }

        private Token LookAhead(int distance = 0)
        {
            // Once we've reached the end of the string, just return EOF tokens. We'll
            // just keeping returning them as many times as we're asked so that the
            // parser's lookahead doesn't have to worry about running out of tokens.
            return _index + distance < _tokenList.Count ?
                _tokenList[_index + distance] : new Token(TokenType.Eof, "");
        }

        private Precedence GetPrecedence()
        {
            IInfixParselet parselet;
            var type = LookAhead().GetTokenType();

            return (_infixParselets.TryGetValue(type, out parselet))
                ? parselet.GetPrecedence() : 0;
        }
    }
}
