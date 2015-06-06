using Calculime.Tokens.Values;

namespace Calculime.Tokens.Operations.UnaryOperations
{
    public class Factorial : UnaryOperation
    {
        public Factorial()
        {
            Symbol = Token.Factorial;
        }

        public override Value ExecuteUnary(Value value)
        {
            value.Val = Fact(value.Val);
            return value;
        }

        public static double Fact(double n)
        {
            if (n <= 1) return 1;

            double result = 1;

            for (var i = n; i > 1; i--)
            {
                result *= n;
            }

            return result;
        }
    }
}
