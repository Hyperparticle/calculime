using System.Collections.Generic;
using PrattParser.Tokens;

namespace PrattParser.Parsers
{
    public class MathLexer
    {
        private const char HexChar = 'x';
        private const char BinaryChar = 'b';

        private readonly string _expression;
        private int _index;
        private readonly List<Token> _tokenList; 

        public MathLexer(string expression)
        {
            _expression = expression.Trim();
            _tokenList = new List<Token>();
        }

        public List<Token> GetTokens()
        {
            while (_index < _expression.Length)
            {
                var c = _expression[_index];

                if (Table.CharToTokenType.ContainsKey(c))           // Handle punctuation
                    ParsePunctuation();
                else if (char.IsDigit(c) || c == Symbol.Period)     // Handle numbers
                    ParseNumber(c);
                else if (char.IsLetter(c))                          // Handle names
                    ParseName();
                else
                    _index++;                                       // Ignore all other characters
            }

            return _tokenList;
        }

        private void ParsePunctuation()
        {
            var start = _index;

            while (_index < _expression.Length)
            {
                var nextSymbol = _expression.Substring(start, _index - start + 1);
                if (!Table.StringToTokenType.ContainsKey(nextSymbol)) break;
                _index++;
            }

            var symbol = _expression.Substring(start, _index - start);

            var token = new Token(Table.StringToTokenType[symbol], symbol);
            _tokenList.Add(token);
        }

        private void ParseNumber(char c)
        {
            var start = _index;

            if (c == Symbol.Zero && _expression.Length > 2 &&
                (_expression[_index] == HexChar || _expression[_index] == BinaryChar))
            {
                _index++;

                while (_index < _expression.Length)
                {
                    if (!char.IsLetterOrDigit(_expression[_index])) break;
                    _index++;
                }
            }
            else
            {
                while (_index < _expression.Length)
                {
                    if (!(char.IsDigit(_expression[_index]) || _expression[_index] == Symbol.Period)) break;
                    _index++;
                }
            }

            var number = _expression.Substring(start, _index - start);

            var token = new Token(TokenType.Number, number);
            _tokenList.Add(token);
        }

        private void ParseName()
        {
            var start = _index;
            while (_index < _expression.Length)
            {
                var text = _expression[_index];
                if (!char.IsLetter(text) && !char.IsDigit(text)) break;
                _index++;
            }

            var name = _expression.Substring(start, _index - start);
            var token = new Token(TokenType.Name, name);
            _tokenList.Add(token);
        }
    }
}
