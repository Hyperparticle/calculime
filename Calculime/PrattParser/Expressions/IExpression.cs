using System.Text;

namespace PrattParser.Expressions
{
    /**
     * Interface for all expression AST node classes.
     */
    public interface IExpression
    {
        /**
         * Pretty-print the expression to a string.
         */
        void Print(StringBuilder builder);
    }
}
