using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PrattParser.Parsers;
using PrattParser.Tokens;

namespace CalculimeUnitTests
{
    [TestClass]
    public class PrattParserUnitTests
    {
        private readonly MathParser _parser = new MathParser();
        private const double Tolerance = 0;

        [TestMethod]
        public void ResultTests()
        {
            TestResult("2+3*5", 2 + 3*5);
            TestResult("2+3*5^2", 2 + 3*Math.Pow(5, 2));
            TestResult("2+3*5/2*2", 2d + 3d*5d/2d*2d);
            TestResult("2pi", 2d*Math.PI);
            TestResult("2pi 2", 2d*Math.PI*2d);
            TestResult("3(3+2)(2*5)", 3*(3 + 2)*(2*5));
            TestResult("100^-1", Math.Pow(100, -1));
            TestResult("3^2+3*3-18", 0);
            TestResult("4^2+3*4-18", 10);
            TestResult("12 * 5", 60d);
            TestResult("-3 + 4", 1d);
            TestResult("5 * (3 + 4)", 35d);

            TestResult("(2*-2+4)/(.1^2-7)", 0);
            TestResult("0.01*.7 + 1.3*2.", 0.01*.7 + 1.3*2);
            TestResult(".2 + 1.", 1.2d);

            Value.SetUserValue("a", 5);
            Value.SetUserValue("b", 5);
            TestResult("2aba", 250);
            TestResult("2abs(-10)", 20);
            TestResult("sqrt(10^2)", 10);

            TestResult("sin(0)", 0);
            TestResult("sin(pi/2)", 1);
            TestResult("sin(pi/4)", Math.Sin(Math.PI/4));
            TestResult("sin((45/180)pi)", Math.Sin((45d/180d)*Math.PI));
            TestResult("tan(pi/2)", Math.Tan(Math.PI/2));

            Value.SetUserValue("ans", 5);
            TestResult("ans+2", 7);

            Value.SetUserValue("ans", 16);
            TestResult("sqrt(ans)+2", 6);

            Value.SetUserValue("ans", 10);
            TestResult("2*-ans", -20);

            Value.SetUserValue("ans", 10);
            Value.SetUserValue("a", 2);
            Value.SetUserValue("n", 3);
            TestResult("a n ans", 60);

            TestResult("2 * e", 2*Math.E);
            TestResult("2e", 2*Math.E);

            //Test("2e10", 2e10);
            //Test("5.0805263425E-5 * 2", 2*5.0805263425E-5);
            //Test("4.35718618402138E+21*2", (4.35718618402138E+21)*2);
            //Test("10E10*2", (10E10)*2);

            TestResult("ln(3^e)", Math.Log(Math.Pow(3, Math.E), Math.E));

            TestResult("Log(1000)", Math.Log(1000));
            TestResult("Log10(1000)", Math.Log10(1000));
            TestResult("Log(27, 3)", 3);
            TestResult("Log(4^4, 4)", 4);
            TestResult("-sin(-4)", -Math.Sin(-4));
            TestResult("max(3+2,3+3)", 6);

            TestResult("min(10,3) - max(0,3)", 0);
            TestResult("min(cos(0.04), sin(0.2) )", Math.Min(Math.Cos(0.04), Math.Sin(0.2)));
            TestResult("max(cos(0.04), 0.3 )", Math.Max(Math.Cos(0.04), 0.4));
            TestResult("cos(2min(pi(1/2), 3.14/2))", Math.Cos(2*Math.Min(Math.PI/2, 3.14/2)));

            //Value.SetUserValue("x", "2pi");
            //Test("2x", Math.PI*4);

            TestResult("2^2^3", Math.Pow(2, Math.Pow(2, 3)));
            TestResult("(2^2)^3", Math.Pow(Math.Pow(2, 2), 3));
            TestResult("4 ^ 3 ^ 2", 262144d);

            TestResult("-(-1)^2", -1);
            TestResult("-1^2", -1);
            TestResult("(-1)^2", 1);
            Value.SetUserValue("x", 0);
            TestResult("-(x-1)^2+4", 3);

            TestResult("--1", 1);
            TestResult("---1", -1);
            TestResult("-+-++1+-+-1", 2);
            TestResult("---4 - --8", -12d);
        }

        [TestMethod]
        public void PrintTests()
        {
            // Function call.
            TestPrint("a()", "a()");
            TestPrint("a(b)", "a(b)");
            TestPrint("a(b, c)", "a(b, c)");
            TestPrint("a(b)(c)", "a(b)(c)");
            TestPrint("a(b) + c(d)", "(a(b) + c(d))");
            TestPrint("a(b ? c : d, e + f)", "a((b ? c : d), (e + f))");

            // Unary precedence.
            TestPrint("~!-+a", "(~(!(-(+a))))");
            TestPrint("a!!!", "(((a!)!)!)");

            // Unary and binary predecence.
            TestPrint("-a * b", "((-a) * b)");
            TestPrint("!a + b", "((!a) + b)");
            TestPrint("~a ^ b", "((~a) ^ b)");
            TestPrint("-a!", "(-(a!))");
            TestPrint("!a!", "(!(a!))");

            // Binary precedence.
            TestPrint("a = b + c * d ^ e - f / g", "(a = ((b + (c * (d ^ e))) - (f / g)))");

            // Binary associativity.
            TestPrint("a = b = c", "(a = (b = c))");
            TestPrint("a + b - c", "((a + b) - c)");
            TestPrint("a * b / c", "((a * b) / c)");
            TestPrint("a ^ b ^ c", "(a ^ (b ^ c))");

            // Conditional operator.
            TestPrint("a ? b : c ? d : e", "(a ? b : (c ? d : e))");
            TestPrint("a ? b ? c : d : e", "(a ? (b ? c : d) : e)");
            TestPrint("a + b ? c * d : e / f", "((a + b) ? (c * d) : (e / f))");

            // Grouping.
            TestPrint("a + (b + c) + d", "((a + (b + c)) + d)");
            TestPrint("a ^ (b + c)", "(a ^ (b + c))");
            TestPrint("(!a)!", "((!a)!)");

            // Numbers.
            TestPrint("-5.4 * .4", "((-5.4) * .4)");
            TestPrint("!0.02 + 7.", "((!0.02) + 7.)");
        }

        private void TestResult(string expression, double expected)
        {
            var actual = _parser.Execute(expression);
            var failed = string.Format("FAILED - Expression {0}, Expected {1}, Actual {2}", expression, expected, actual);

            Assert.AreEqual(expected, actual, Tolerance, failed);
            Value.ClearUserValues();
        }

        private void TestPrint(string expression, string expected)
        {
            var actual = _parser.ParseExpression(expression);
            var failed = string.Format("FAILED - Expression {0}, Expected {1}, Actual {2}", expression, expected, actual);

            Assert.AreEqual(expected, actual, failed);
            Value.ClearUserValues();
        }
    }
}
