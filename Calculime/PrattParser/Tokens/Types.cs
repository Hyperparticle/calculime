using System;
using System.Collections.Generic;
using System.Linq;

namespace PrattParser.Tokens
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
        Percent,
        Name,
        Number,
        Eof
    }

    public enum FunctionType
    {
        Sine,
        Cosine,
        Tangent,
        Arcsine,
        Arccosine,
        Arctangent,
        AbsoluteValue,
        NaturalLog,
        LogBase10,
        SquareRoot,
        Round,
        Floor,
        Ceiling,
        Max,
        Min
    }

    public static class Table
    {
        // Dictionaries to convert between strings and their type
        public static readonly Dictionary<char, TokenType> CharToTokenType = 
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
            { ':', TokenType.Colon },
            { '%', TokenType.Percent }
        };

        public static readonly Dictionary<TokenType, char> TokenTypeToChar = 
            CharToTokenType.ToDictionary(x => x.Value, x => x.Key);

        public static readonly Dictionary<string, double> StringToValue =
        new Dictionary<string, double>()
        {
            { "pi", Math.PI },
            { "e", Math.E }
        };
    }
}
