using System.Text;

namespace PrattParser.Expressions
{
    /**
     * Interface for all expression AST node classes.
     */
    public interface IExpression
    {
        /**
         * Execute the expression and return a result
         */
        double Execute();

        /**
         * Pretty-print the expression to a string.
         */
        void Print(StringBuilder builder);
    }
}
