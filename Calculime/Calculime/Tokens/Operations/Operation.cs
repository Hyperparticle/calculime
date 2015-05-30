using Calculime.DataStructures.Values;

namespace Calculime.Tokens.Operations
{
    public abstract class Operation
    {
        // Indicates Prescedence
        public enum Priority { Lowest, Low, Medium, High, Highest }

        public int Precedence { get;  protected set; }
        public bool LeftAssociative { get; set; }
        public string Symbol { get; protected set; }
        public int NumArguments { get; protected set; }

		public abstract Value Execute(params Value[] values);

        public override string ToString() { return Symbol; }
    }
}
