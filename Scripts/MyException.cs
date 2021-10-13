using System;


namespace ArtomStatsenko
{
    public class MyException : Exception
    {
        public MyException(string message) : base(message) { }
    }
}
