using PrattParser.Parselets;
using PrattParser.Tokens;

namespace PrattParser.Parsers
{
    public class MathParser : Parser
    {
        public MathParser()
        {
            // Register all of the parselets for the grammar.

            // Register the ones that need special parselets.
            Register(TokenType.Function, new FunctionParselet());
            Register(TokenType.Value, new ValueParselet());
            Register(TokenType.Number, new NumberParselet());
            Register(TokenType.Assign, new AssignParselet());
            Register(TokenType.Question, new ConditionalParselet());
            Register(TokenType.LeftParen, new GroupParselet());

            // Implicit multiplication
            Implicit(TokenType.Function);
            Implicit(TokenType.Value);
            Implicit(TokenType.Number);
            Implicit(TokenType.LeftParen);

            // Register the simple operator parselets.
            Prefix(TokenType.Plus, Precedence.Prefix);
            Prefix(TokenType.Minus, Precedence.Prefix);
            Prefix(TokenType.Tilde, Precedence.Prefix);
            Prefix(TokenType.Bang, Precedence.Prefix);

            // Sum and Product operators
            InfixLeft(TokenType.Plus, Precedence.Sum);
            InfixLeft(TokenType.Minus, Precedence.Sum);

            InfixLeft(TokenType.Asterisk, Precedence.Product);
            InfixLeft(TokenType.Slash, Precedence.Product);
            InfixLeft(TokenType.Percent, Precedence.Product);

            // Bitwise operators
            InfixLeft(TokenType.Ampersand, Precedence.LogicalAnd);
            InfixLeft(TokenType.Pipe, Precedence.LogicalOr);
            InfixLeft(TokenType.BitLeft, Precedence.Shift);
            InfixLeft(TokenType.BitRight, Precedence.Shift);

            InfixRight(TokenType.Caret, Precedence.Exponent);

            // For kicks, we'll make "!" both prefix and postfix, kind of like ++.
            Postfix(TokenType.Bang, Precedence.Postfix);
            //Postfix(TokenType.RightParen, Precedence.Postfix);
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

        public void Implicit(TokenType token)
        {
            Register(token, new ImplicitParselet());
        }
    }
}
