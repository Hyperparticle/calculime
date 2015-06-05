using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrattParser
{
    public enum TokenType
    {
        LeftParen,
        RightParen,
        Comma,
        Assign,
        Plus,
        Minus,
        Asterisk,
        Slash,
        Caret,
        Tilde,
        Bang,
        Question,
        Colon,
        Name,
        Eof
    }

    public static class Table
    {
        // Dictionaries to convert between string and TokenType
        public static readonly Dictionary<char, TokenType> DTokenType = 
        new Dictionary<char, TokenType>()
        {
            { '(', TokenType.LeftParen },
            { ')', TokenType.RightParen },
            { ',', TokenType.Comma },
            { '=', TokenType.Assign },
            { '+', TokenType.Plus },
            { '-', TokenType.Minus },
            { '*', TokenType.Asterisk },
            { '/', TokenType.Slash },
            { '^', TokenType.Caret },
            { '~', TokenType.Tilde },
            { '!', TokenType.Bang },
            { '?', TokenType.Question },
            { ':', TokenType.Colon }
        };

        public static readonly Dictionary<TokenType, char> DTokenString = 
            DTokenType.ToDictionary(x => x.Value, x => x.Key);
    }
}
