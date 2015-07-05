using System;
using System.Collections;
using System.Collections.Generic;
using PrattParser.Tokens;

namespace PrattParser.Parsers
{
    /**
     
     */

    /// <summary>
    /// A simple Lexer. It takes a string input and splits it into a series of
    /// Tokens. Operators and punctuation are mapped to unique keywords. Names,
    /// which can be any series of letters, are turned into NAME tokens. They can 
    /// contain (but not begin with) numbers. Numbers, which can be integers, 
    /// decimals, or hex/binary strings, are turned into NUMBER tokens. 
    /// All other characters are ignored (except to separate names).
    /// </summary>
    public class Lexer : IEnumerator<Token>
    {
        private const char HexChar = 'x';
        private const char BinaryChar = 'b';

        private readonly string _text;
        private int _index;

        /**
         * Creates a new Lexer to tokenize the given string.
         */
        public Lexer(string text)
        {
            _index = 0;
            _text = text;
            Current = null;
        }

        public bool MoveNext()
        {
            while (_index < _text.Length)
            {
                var c = _text[_index++];

                // Handle punctuation
                if (Table.CharToTokenType.ContainsKey(c))
                {
                    var start = _index - 1;

                    while (_index < _text.Length)
                    {
                        var nextSymbol = _text.Substring(start, _index - start + 1);
                        if (!Table.StringToTokenType.ContainsKey(nextSymbol)) break;
                        _index++;
                    }

                    var symbol = _text.Substring(start, _index - start);

                    Current = new Token(Table.StringToTokenType[symbol], symbol);
                    return true;
                }

                // Handle numbers
                if (char.IsDigit(c) || c == Symbol.Period)
                {
                    var start = _index - 1;

                    if (c == Symbol.Zero && _text.Length > 2 && (_text[_index] == HexChar || _text[_index] == BinaryChar))
                    {
                        _index++;

                        while (_index < _text.Length)
                        {
                            if (!(char.IsLetterOrDigit(_text[_index]))) break;
                            _index++;
                        }
                    }
                    else
                    {
                        while (_index < _text.Length)
                        {
                            if (!(char.IsDigit(_text[_index]) || _text[_index] == Symbol.Period)) break;
                            _index++;
                        }
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
                        var text = _text[_index];
                        if (!char.IsLetter(text) && !char.IsDigit(text)) break;
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
