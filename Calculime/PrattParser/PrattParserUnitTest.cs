using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrattParser
{
    public class PrattParserUnitTest
    {

        private Term m_term = new Term();

        public void UnitTest()
        {
            Assert("2+3*5", 2 + 3*5);
            Assert("2+3*5^2", 2 + 3*Math.Pow(5, 2));
            Assert("2+3*5/2*2", 2d + 3d*5d/2d*2d);
            Assert("2pi", 2d*Math.PI);
            Assert("2pi2", 2d*Math.PI*2d);
            Assert("3(3+2)(2*5)", 3*(3 + 2)*(2*5));
            Assert("100^-1", Math.Pow(100, -1));
            Assert("3^2+3*3-18", 0);
            Assert("4^2+3*4-18", 10);

            Assert("(2*-2+4)/(x^2-7)", 0);

            m_term.SetVar("a", 5);
            m_term.SetVar("b", 5);
            Assert("2aba", 250);
            Assert("2abs(-10)", 20);
            Assert("sqrt(10^2)", 10);

            Assert("sin(0)", 0);
            Assert("sin(pi/2)", 1);
            Assert("sin(pi/4)", Math.Sin(Math.PI/4));
            Assert("sin((45/180)pi)", Math.Sin((45d/180d)*Math.PI));
            Assert("tan(pi/2)", Math.Tan(Math.PI/2));

            m_term.SetVar("ans", 5);
            Assert("ans+2", 7);

            m_term.SetVar("ans", 16);
            Assert("sqrt(ans)+2", 6);

            m_term.SetVar("ans", 10);
            Assert("2*-ans", -20);

            m_term.SetVar("ans", 10);
            m_term.SetVar("a", 2);
            m_term.SetVar("n", 3);
            Assert("a n ans", 60);

            Assert("2 * e", 2*Math.E);
            Assert("2e", 2*Math.E);
            Assert("2e10", (double) 2e10);
            Assert("5.0805263425E-5 * 2", 2*(double) 5.0805263425E-5);
            Assert("4.35718618402138E+21*2", ((double) 4.35718618402138E+21)*2);
            Assert("10E10*2", ((double) 10E10)*2);

            Assert("ln(3^e)", Math.Log(Math.Pow(3, Math.E), Math.E /*3*/));

            Assert("Log(1000)", 3);
            Assert("Log(27, 3)", 3);
            Assert("Log(4^4, 4)", 4);
            Assert("-sin(-4)", -Math.Sin(-4));
            Assert("max(3+2,3+3)", 6);

            Assert("min(10,3) - max(0,3)", 0);
            Assert("min(cos(0.04), sin(0.2) )", Math.Min(Math.Cos(0.04), Math.Sin(0.2)));
            Assert("max(cos(0.04), 0.3 )", Math.Max(Math.Cos(0.04), 0.4));
            Assert("cos(2min(pi(1/2), 3.14/2))", Math.Cos(2*Math.Min(Math.PI/2, 3.14/2)));

            m_term.SetVar("x", "2pi");
            Assert("2x", Math.PI*4);

            Assert("2^2^3", Math.Pow(2, Math.Pow(2, 3)));
            Assert("(2^2)^3", Math.Pow(Math.Pow(2, 2), 3));

            Assert("-(-1)^2", -1);
            Assert("-1^2", -1);
            Assert("(-1)^2", 1);
            m_term.SetVar("x", 0);
            Assert("-(x-1)^2+4", 3);
        }

        private void Assert(string equation, double result)
        {
            try
            {
                m_term.Parse(equation);
                if (m_term.Value != result)
                {
                    string text = string.Format("FAILED - Equation {0}, Parsed {1}, Value {2}, Expected {3}", equation,
                        m_term.ToString(), m_term.Value, result);
                    throw new EquationUnitTestException(equation, text);
                }
                Console.WriteLine(string.Format("PASSED - Equation {0}, Parsed {1}, Value {2}", equation,
                    m_term.ToString(), m_term.Value));
            }
            catch (Exception error)
            {
                throw new EquationUnitTestException(equation, error.Message);
            }
            m_term.ClearVars();

        }

        private class EquationUnitTestException : Exception
        {
            public string Equation { get; set; }

            public EquationUnitTestException(string equation, string message) : base(message)
            {
                Equation = equation;
            }
        }
    }
}
