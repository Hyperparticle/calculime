using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Calculime.Operations
{
    public interface Value
    {
        //Binary operations
        Value add(Value other);
        Value subtract(Value other);
        Value multiply(Value other);
        Value divide(Value other);

        //Unary operations
        Value negate();
        Value squareRoot();
        Value inverse();
        Value percent();

        //Value methods
        Value create(string s);
        string addDigit(string number, string digit);
    }
}
