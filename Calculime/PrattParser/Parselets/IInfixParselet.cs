using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PrattParser.Expressions;

namespace PrattParser.Parselets
{
    /**
     * One of the two parselet interfaces used by the Pratt parser. An
     * InfixParselet is associated with a token that appears in the middle of the
     * expression it parses. Its parse() method will be called after the left-hand
     * side has been parsed, and it in turn is responsible for parsing everything
     * that comes after the token. This is also used for postfix expressions, in
     * which case it simply doesn't consume any more tokens in its parse() call.
     */
    public interface IInfixParselet
    {
        IExpression Parse(Parser parser, IExpression left, Token token);
        int GetPrecedence();
    }
}
