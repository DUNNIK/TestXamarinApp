using System;

namespace TestXamarinApp.Exceptions
{
    public class GetXmlException : Exception
    {
        public GetXmlException() : base("Unable to get XML information!")
        {
        }
    }
}