using PrattParser.Parselets;
using PrattParser.Tokens;

namespace PrattParser.Parsers
{
    public class MathParser : Parser
    {
        /**
         * Extends the generic Parser class with support for parsing the actual 
         * Math grammar.
         */
        public MathParser(Lexer lexer) : base(lexer)
        {
            // Register all of the parselets for the grammar.

            // Register the ones that need special parselets.
            Register(TokenType.Name,        new NameParselet());
            Register(TokenType.Assign,      new AssignParselet());
            Register(TokenType.Question,    new ConditionalParselet());
            Register(TokenType.LeftParen,   new GroupParselet());
            Register(TokenType.LeftParen,   new CallParselet());
            //Register(TokenType.RightParen,  new GroupParselet());
            //Register(TokenType.RightParen,  new CallParselet());

            // Register the simple operator parselets.
            Prefix(TokenType.Plus,  Precedence.Prefix);
            Prefix(TokenType.Minus, Precedence.Prefix);
            Prefix(TokenType.Tilde, Precedence.Prefix);
            Prefix(TokenType.Bang,  Precedence.Prefix);

            // For kicks, we'll make "!" both prefix and postfix, kind of like ++.
            Postfix(TokenType.Bang, Precedence.Postfix);

            InfixLeft(TokenType.Plus,       Precedence.Sum);
            InfixLeft(TokenType.Minus,      Precedence.Sum);
            InfixLeft(TokenType.Asterisk,   Precedence.Product);
            InfixLeft(TokenType.Slash,      Precedence.Product);
            InfixRight(TokenType.Caret,     Precedence.Exponent);
        }

        /**
         * Registers a postfix unary operator parselet for the given token and
         * precedence.
         */
        public void Postfix(TokenType token, Precedence precedence)
        {
            Register(token, new PostfixOperatorParselet(precedence));
        }

        /**
         * Registers a prefix unary operator parselet for the given token and
         * precedence.
         */
        public void Prefix(TokenType token, Precedence precedence)
        {
            Register(token, new PrefixOperatorParselet(precedence));
        }

        /**
         * Registers a left-associative binary operator parselet for the given token
         * and precedence.
         */
        public void InfixLeft(TokenType token, Precedence precedence)
        {
            Register(token, new BinaryOperatorParselet(precedence, false));
        }

        /**
         * Registers a right-associative binary operator parselet for the given token
         * and precedence.
         */
        public void InfixRight(TokenType token, Precedence precedence)
        {
            Register(token, new BinaryOperatorParselet(precedence, true));
        }
    }
}
