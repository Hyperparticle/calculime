using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrattParser
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
        private readonly Dictionary<char, TokenType> _dPunctuators =
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

            // Register all of the TokenTypes that are explicit punctuators.
            foreach (TokenType type in TokenType.GetValues(typeof(TokenType)))
            {
                char punctuator;
                if (Table.DTokenString.TryGetValue(type, out punctuator))
                    _dPunctuators.Add(punctuator, type);

            }
        }
    }
}
