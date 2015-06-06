namespace Calculime.Tokens.Values
{
	public class DecimalValue : Value
	{
	    private double _value;

		// Constructors
		public DecimalValue(string s)
		{
			_value = double.Parse(s);
		}

		public DecimalValue(double value)
		{
			_value = value;
		}

        public override double Val
        {
            get { return _value; }
            set { _value = value; }
        }

		public override string ToString()
		{
			return Val.ToString();
		}
	}
}
