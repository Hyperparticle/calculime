using Calculime.DataStructures.Tree;
using Calculime.Tokens;

namespace Calculime
{
    /**
     * Responsible for parsing string expressions and returning the result
     */
    public class ExpressionParser
    {
        private readonly ExpressionTree<Token> _expressionTree;

        public ExpressionParser()
        {
            _expressionTree = new ExpressionTree<Token>();
        }
		
        public string Parse(string expression)
        {
			_expressionTree.Build(expression);
			return _expressionTree.Calculate();
        }
    }
}
