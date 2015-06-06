using System;
using System.Text;

namespace PrattParser.Parsers
{
    public class ParseTest
    {
        private static int _passed = 0;
        private static int _failed = 0;

        public static void Parse()
        {
            // Function call.
            Test("a()", "a()");
            Test("a(b)", "a(b)");
            Test("a(b, c)", "a(b, c)");
            Test("a(b)(c)", "a(b)(c)");
            Test("a(b) + c(d)", "(a(b) + c(d))");
            Test("a(b ? c : d, e + f)", "a((b ? c : d), (e + f))");
    
            // Unary precedence.
            Test("~!-+a", "(~(!(-(+a))))");
            Test("a!!!", "(((a!)!)!)");
    
            // Unary and binary predecence.
            Test("-a * b", "((-a) * b)");
            Test("!a + b", "((!a) + b)");
            Test("~a ^ b", "((~a) ^ b)");
            Test("-a!",    "(-(a!))");
            Test("!a!",    "(!(a!))");
    
            // Binary precedence.
            Test("a = b + c * d ^ e - f / g", "(a = ((b + (c * (d ^ e))) - (f / g)))");
    
            // Binary associativity.
            Test("a = b = c", "(a = (b = c))");
            Test("a + b - c", "((a + b) - c)");
            Test("a * b / c", "((a * b) / c)");
            Test("a ^ b ^ c", "(a ^ (b ^ c))");
    
            // Conditional operator.
            Test("a ? b : c ? d : e", "(a ? b : (c ? d : e))");
            Test("a ? b ? c : d : e", "(a ? (b ? c : d) : e)");
            Test("a + b ? c * d : e / f", "((a + b) ? (c * d) : (e / f))");
    
            // Grouping.
            Test("a + (b + c) + d", "((a + (b + c)) + d)");
            Test("a ^ (b + c)", "(a ^ (b + c))");
            Test("(!a)!",    "((!a)!)");

            // Numbers.
            Test("-5.4 * .4", "((-5.4) * .4)");
            Test("!0.02 + 7.", "((!0.02) + 7.)");
    
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
        public static void Test(string source, string expected) 
        {
            var lexer = new Lexer(source);
            Parser parser = new MathParser(lexer);
    
            try 
            {
                var result = parser.ParseExpression();
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
    }
}
