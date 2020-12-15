using System;

namespace TestXamarinApp.Exceptions
{
    public class GetOffersException : Exception
    {
        public GetOffersException() : base("Unable to get offers!")
        {
        }
    }
}