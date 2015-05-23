using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Calculime.DataStructures;

namespace Calculime.Operations
{
    public abstract class Operation
    {
        //static enum priority {highest, high, medium, low, lowest}

        //The precedence for operations. 
        //For example, unary operations have a higher precedence than binary operations. 
        public static int HIGHEST = 5;
        public static int HIGH = 4;
        public static int MEDIUM = 3;
        public static int LOW = 2;
        public static int LOWEST = 1;

        public int Precedence { get;  protected set; }
        public bool LeftAssociative { get; set; }
        public string Symbol { protected get; set; }

        public override string ToString()
        {
            return Symbol;
        }

        public abstract void execute();
    }
}
