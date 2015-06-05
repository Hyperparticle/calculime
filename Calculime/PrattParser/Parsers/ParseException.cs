using System;

namespace PrattParser.Parsers
{
    public class ParseException : Exception
    {
        public ParseException(string message) : base(message)
        {
            
        }
    }
}
