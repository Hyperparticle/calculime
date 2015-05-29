namespace Calculime.DataStructures.Values
{
	class DecimalValue : Value
	{
		// Constructors
		public DecimalValue(string s)
		{
			Val = double.Parse(s);
		}

		public DecimalValue(double value)
		{
			Val = value;
		}

		public override string ToString()
		{
			return Val.ToString();
		}
	}
}
