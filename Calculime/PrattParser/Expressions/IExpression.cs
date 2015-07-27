using System.Text;

namespace PrattParser.Expressions
{
    /**
     * Interface for all expression AST node classes.
     */
    public interface IExpression
    {
        /**
         * Calculate the expression and return a result
         */
        double Calculate();

        /**
         * Pretty-print the expression to a string.
         */
        void Print(StringBuilder builder);
    }
}
