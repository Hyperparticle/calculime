using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures;
using Calculime.DataStructures.Values;

namespace Calculime.Operations
{
    public abstract class Operation
    {
        public enum Priority { lowest, low, medium, high, highest }

        public int Precedence { get;  protected set; }
        public bool LeftAssociative { get; set; }
        public string Symbol { get; protected set; }

		public abstract Value execute(params Value[] values);

        public override string ToString()
        {
            return Symbol;
        }
    }
}
