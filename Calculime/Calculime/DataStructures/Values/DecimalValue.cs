using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
