using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrattParser
{
    public class ParseTest
    {
        private static int _passed = 0;
        private static int _failed = 0;

        public static void main(string[] args)
        {
            // Function call.
            test("a()", "a()");
            test("a(b)", "a(b)");
            test("a(b, c)", "a(b, c)");
            test("a(b)(c)", "a(b)(c)");
            test("a(b) + c(d)", "(a(b) + c(d))");
            test("a(b ? c : d, e + f)", "a((b ? c : d), (e + f))");
    
            // Unary precedence.
            test("~!-+a", "(~(!(-(+a))))");
            test("a!!!", "(((a!)!)!)");
    
            // Unary and binary predecence.
            test("-a * b", "((-a) * b)");
            test("!a + b", "((!a) + b)");
            test("~a ^ b", "((~a) ^ b)");
            test("-a!",    "(-(a!))");
            test("!a!",    "(!(a!))");
    
            // Binary precedence.
            test("a = b + c * d ^ e - f / g", "(a = ((b + (c * (d ^ e))) - (f / g)))");
    
            // Binary associativity.
            test("a = b = c", "(a = (b = c))");
            test("a + b - c", "((a + b) - c)");
            test("a * b / c", "((a * b) / c)");
            test("a ^ b ^ c", "(a ^ (b ^ c))");
    
            // Conditional operator.
            test("a ? b : c ? d : e", "(a ? b : (c ? d : e))");
            test("a ? b ? c : d : e", "(a ? (b ? c : d) : e)");
            test("a + b ? c * d : e / f", "((a + b) ? (c * d) : (e / f))");
    
            // Grouping.
            test("a + (b + c) + d", "((a + (b + c)) + d)");
            test("a ^ (b + c)", "(a ^ (b + c))");
            test("(!a)!",    "((!a)!)");
    
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
        public static void test(String source, String expected) 
        {
            Lexer lexer = new Lexer(source);
            Parser parser = new MathParser(lexer);
    
            try 
            {
                var result = parser.ParseExpression();
                StringBuilder builder = new StringBuilder();
                result.Print(builder);
                String actual = builder.ToString();
      
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
