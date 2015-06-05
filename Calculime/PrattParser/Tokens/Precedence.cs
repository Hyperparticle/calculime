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
        Assignment  = 1,
        Conditional = 2,
        Sum         = 3,
        Product     = 4,
        Exponent    = 5,
        Prefix      = 6,
        Postfix     = 7,
        Call        = 8
    }
}
