using System;

namespace ECDC.OutlookExtender.Exceptions
{
    public class SecurityException : Exception
    {
        public SecurityException(string message, Exception ex) : base(message, ex) { }
    }
}
