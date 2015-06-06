using System;
using System.Text;
using PrattParser.Exceptions;
using PrattParser.Parsers;

namespace Calculime.Tests
{
    public class ParseTest
    {
        private static int _passed;
        private static int _failed;

        public static void Parse()
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
            TestPrint("-a!",    "(-(a!))");
            TestPrint("!a!",    "(!(a!))");
    
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
            TestPrint("(!a)!",    "((!a)!)");

            // Numbers.
            TestPrint("-5.4 * .4", "((-5.4) * .4)");
            TestPrint("!0.02 + 7.", "((!0.02) + 7.)");

            // Values.
            TestValue("12 * 5", 60d);
            TestValue("-3 + 4", 1d);
            TestValue("5 * (3 + 4)", 35d);
            TestValue("4 ^ 3 ^ 2", 262144d);
            TestValue(".2 + 1.", 1.2d);
            TestValue("---4 - --8", -12d);
    
            // Show the results.
            if (_failed == 0) {
                Console.WriteLine("Passed all " + _passed + " tests.");
            } else {
                Console.WriteLine("----");
                Console.WriteLine("Failed " + _failed + " out of " +
                    (_failed + _passed) + " tests.");
            }
        }

        /**
         * Parses the given chunk of code and verifies that it matches the expected
         * pretty-printed result.
         */
        public static void TestPrint(string source, string expected) 
        {
            Parser parser = new MathParser();
    
            try 
            {
                var result = parser.ParseExpression(source);
                var builder = new StringBuilder();
                result.Print(builder);
                var actual = builder.ToString();
      
                if (expected.Equals(actual)) 
                {
                    _passed++;
                } 
                else 
                {
                    _failed++;
                    Console.WriteLine("[FAIL] Expected: " + expected);
                    Console.WriteLine("         Actual: " + actual);
                }
            } 
            catch(ParseException ex) 
            {
                _failed++;
                Console.WriteLine("[FAIL] Expected: " + expected);
                Console.WriteLine("          Error: " + ex.Message);
            }
        }

        /**
         * Parses the given chunk of code and verifies that it matches the expected
         * executed value.
         */
        public static void TestValue(string source, double expected)
        {
            Parser parser = new MathParser();

            try
            {
                var result = parser.ParseExpression(source);
                var actual = result.Execute();

                if (expected.Equals(actual))
                {
                    _passed++;
                }
                else
                {
                    _failed++;
                    Console.WriteLine("[FAIL] Expected: " + expected);
                    Console.WriteLine("         Actual: " + actual);
                }
            }
            catch (ParseException ex)
            {
                _failed++;
                Console.WriteLine("[FAIL] Expected: " + expected);
                Console.WriteLine("          Error: " + ex.Message);
            }
        }
    }
}
