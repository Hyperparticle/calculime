using System.Linq;
using PrattParser.Tokens;

namespace Calculime
{
    public class MathFormatter
    {
        private string _expression;

        private int _parens; // TODO: Properly format parentheses

        public string Format(string expression)
        {
            _expression = expression;

            // Base Case
            if (string.IsNullOrWhiteSpace(expression))
                return Symbol.Zero.ToString();

            // Insert Parentheses
            expression = FormatParentheses(expression);
            expression = FormatImplicit(expression);

            // TODO: Format the expression

            return expression;
        }

        private static string FormatParentheses(string expression)
        {
            var openParens = 0;

            foreach (var c in expression)
            {
                switch (c)
                {
                    case Symbol.LeftParen:
                        openParens++;
                        break;

                    case Symbol.RightParen:
                        if (openParens == 0)
                            expression = expression.Insert(0, Symbol.LeftParen.ToString());
                        else
                            openParens--;
                        break;
                }
            }

            if (openParens > 0)
                expression += new string(Symbol.RightParen, openParens);


            return expression;
        }

        private static string FormatImplicit(string expression)
        {
            return expression.Replace(")(", ")*(");
        }
    }
}
