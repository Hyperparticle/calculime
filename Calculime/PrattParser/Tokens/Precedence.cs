namespace PrattParser.Tokens
{
    /**
     * Defines the different precendence levels used by the infix parsers. These
     * determine how a series of infix expressions will be grouped. For example,
     * "a + b * c - d" will be parsed as "(a + (b * c)) - d" because "*" has higher
     * precedence than "+" and "-". Here, bigger numbers mean higher precedence.
     */
    public enum Precedence
    {
        // Ordered in increasing precedence.
        Default,        // 0
        Assignment,     // 1, etc.
        Conditional,
        ConditionalOr,
        ConditionalAnd,
        LogicalOr,
        LogicalXor,
        LogicalAnd,
        Equality,
        Relational,
        Shift,
        Sum,
        Product,
        Exponent,
        Prefix,
        Postfix,
        Call
    }
}
