using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures;
using Calculime.DataStructures.Tree;
using Calculime.DataStructures.Values;
using Calculime.Operations;
using Calculime.Operations.BinaryOperations;

namespace Calculime
{
    /**
     * Responsible for parsing string expressions and returning the result
     */
    class ExpressionParser
    {
        ExpressionTree<Token> expressionTree;

        public ExpressionParser()
        {
            expressionTree = new ExpressionTree<Token>();
        }
		
        public string Parse(string expression)
        {
			expressionTree.Build(expression);
			return expressionTree.Calculate();
        }
    }
}
