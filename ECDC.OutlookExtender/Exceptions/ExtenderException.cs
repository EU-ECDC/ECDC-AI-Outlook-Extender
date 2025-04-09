using System;

namespace ECDC.OutlookExtender.Exceptions
{
    public class ExtenderException : Exception
    {
        public ExtenderException(string message) : base(message) { }
    }
}
