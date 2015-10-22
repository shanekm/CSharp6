using System;

namespace EventInitializers
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandler<EventArgs> log = (o, e) => Console.WriteLine("hit!");
            User user = new User()
                           {
                               Name = "Scott",
                               Speaking += log // This was no allowed prior c# 6.0
                           };
        }
    }
}
