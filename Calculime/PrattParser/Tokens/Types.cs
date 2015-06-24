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
        Bang,
        Question,
        Colon,
        Percent,
        Tilde,
        Ampersand,
        Pipe,
        LessThan,
        GreaterThan,
        BitLeft,
        BitRight,
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
        new Dictionary<char, TokenType>
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
            { '!', TokenType.Bang },
            { '?', TokenType.Question },
            { ':', TokenType.Colon },
            { '%', TokenType.Percent },
            { '~', TokenType.Tilde },
            { '&', TokenType.Ampersand },
            { '|', TokenType.Pipe },
            { '<', TokenType.LessThan },
            { '>', TokenType.GreaterThan }
        };

        public static readonly Dictionary<string, TokenType> StringToTokenType = 
        new Dictionary<string, TokenType>
        {
            { "(", TokenType.LeftParen },
            { ")", TokenType.RightParen },
            { ",", TokenType.Comma },
            { "=", TokenType.Assign },
            { "+", TokenType.Plus },
            { "-", TokenType.Minus },
            { "*", TokenType.Asterisk },
            { "/", TokenType.Slash },
            { "^", TokenType.Caret },
            { "!", TokenType.Bang },
            { "?", TokenType.Question },
            { ":", TokenType.Colon },
            { "%", TokenType.Percent },
            { "~", TokenType.Tilde },
            { "&", TokenType.Ampersand },
            { "|", TokenType.Pipe },
            { "<", TokenType.LessThan },
            { ">", TokenType.GreaterThan },
            { "<<", TokenType.BitLeft },
            { ">>", TokenType.BitRight }
        };

        public static readonly Dictionary<TokenType, string> TokenTypeToString = 
            StringToTokenType.ToDictionary(x => x.Value, x => x.Key);
    }
}
