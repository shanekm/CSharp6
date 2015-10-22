using System;

namespace Start
{
    class Program
    {
        static void Main(string[] args)
        {
        }
    }

    public class User
    {
        // Old way
        // The only way to set Id1 was through the constructor
        public Guid Id1 {get; protected set;}

        // New way
        // Auto property initializer
        public Guid Id2 { get; } = Guid.NewGuid;
    }
}
