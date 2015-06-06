using System;
using System.Collections;
using System.Collections.Generic;
using PrattParser2.Tokens;

namespace PrattParser2.Parsers
{
    /**
     * A very primitive lexer. Takes a string and splits it into a series of
     * Tokens. Operators and punctuation are mapped to unique keywords. Names,
     * which can be any series of letters, are turned into NAME tokens. All other
     * characters are ignored (except to separate names). Numbers and strings are
     * not supported. This is really just the bare minimum to give the parser
     * something to work with.
     */
    public class Lexer : IEnumerator<Token>
    {
        private readonly Dictionary<char, TokenType> _punctuators =
            new Dictionary<char, TokenType>();

        private readonly string _text;
        private int _index = 0;

        /**
         * Creates a new Lexer to tokenize the given string.
         */
        public Lexer(string text)
        {
            _index = 0;
            _text = text;
            Current = null;

            // Register all of the TokenTypes that are explicit punctuators.
            foreach (TokenType type in Enum.GetValues(typeof(TokenType)))
            {
                char punctuator;
                if (Table.DTokenString.TryGetValue(type, out punctuator))
                    _punctuators.Add(punctuator, type);
            }
        }

        public bool MoveNext()
        {
            while (_index < _text.Length)
            {
                var c = _text[_index++];

                // Handle punctuation
                if (_punctuators.ContainsKey(c))
                {
                    Current = new Token(_punctuators[c], c.ToString());
                    return true;
                }

                // Handle numbers
                if (char.IsDigit(c) || c == Symbol.Period)
                {
                    var start = _index - 1;
                    while (_index < _text.Length)
                    {
                        if (!(char.IsDigit(_text[_index]) || _text[_index] == Symbol.Period)) break;
                        _index++;
                    }

                    var number = _text.Substring(start, _index - start);

                    Current = new Token(TokenType.Number, number);
                    return true;
                }

                // Handle names
                if (char.IsLetter(c))
                {
                    var start = _index - 1;
                    while (_index < _text.Length)
                    {
                        if (!char.IsLetter(_text[_index])) break;
                        _index++;
                    }

                    var name = _text.Substring(start, _index-start);
                    Current = new Token(TokenType.Name, name);
                    return true;
                }

                // Ignore all other characters
            }

            // Once we've reached the end of the string, just return EOF tokens. We'll
            // just keeping returning them as many times as we're asked so that the
            // parser's lookahead doesn't have to worry about running out of tokens.
            Current = new Token(TokenType.Eof, "");
            return true;
        }

        public Token Current { get; private set; }

        object IEnumerator.Current
        {
            get { return Current; }
        }

        public void Reset()
        {
            _index = 0;
        }

        public void Dispose()
        {
            throw new NotImplementedException();
        }
    }
}
