using System;

namespace PrattParser2.Parsers
{
    public class ParseException : Exception
    {
        public ParseException(string message) : base(message)
        {
            
        }
    }
}
