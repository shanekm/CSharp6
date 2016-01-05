using System;
using System.Collections.Generic;

namespace CSharp
{
    public class Program
    {
        private static void Main(string[] args)
        {
            // 1. Auto-property initializers 
            var p = new Person();
            p.Title = "Test";
            //p.Age = 5; // Error, no setter
            //p.Age is 10

            // 2. Index initializers
            p.Stats = new Dictionary<string, string>()
            {
                ["Bob"] = "10 points",
                ["Steve"] = "12 points"
            };

            // 3. String interpolation
            Console.WriteLine($"{p.Id} and some string: {p.Age}");

            // 4. Expression bodied functions & properties
            var ageFromProperty = p.DoubleAgeProperty;
            var ageFromMethod = p.DoubleAgeMethod(10);

            // 5. Null conditional operator
            var name = p.FullName?.Length; // no exception, gets null
            name = p.FullName?.Length ?? 5;

            // Events
            p.OnChange += P_OnChange;
            p.DoChange(); 

            // 6. nameOf expression
            p.DoSomething(null);
        }

        private static void P_OnChange(object sender, EventArgs e)
        {
            Console.WriteLine("called onChange");
        }
    }

    public class Person
    {
        public Person()
        {
            Name = string.Empty; // same as below    
            Age = 8; // Constructor takes presendece
        }

        public Guid Id { get; } = Guid.NewGuid(); // Auto-property initializers 
        public string Name { get; protected set; } = string.Empty;
        public int Age { get; } = 15;
        public string FullName { get; } = null;
        public double Currency { get; } = 10.5d;
        public string Title { get; set; } = "Visual C# 6.0";


        public Dictionary<string, string> Stats { get; set; }  // Index initializers


        // Expression bodied functions and properties
        public double DoubleAgeMethod(int age) => age * 2 * Age;    // properties can be used as well
        public double DoubleAgeProperty => 2 * Age;                 // property without params


        // Null conditional operator
        //  if (action != null && action.Method != null){ - prior to C# 6
        //	    name = action.Method.Name;
        //  }
		//  var name = action?.Method?.Name; // if action is null it will return null, otherwise it will continue
        //  var name = action?.Method?.Name ?? "no name" // setting "no name" if all are null


        // Null conditional operator with Events
        public event EventHandler<EventArgs> OnChange; // pointer
        public void DoChange()
        {
            // Old
            //if (OnChange != null)
            //{
            //    OnChange(this, new EventArgs());
            //}

            OnChange?.Invoke(this, new EventArgs()); // anyone listing?, if so execute
        }

        // nameOf expression
        public void DoSomething(string newName)
        {
            if (newName == null) throw new Exception(nameof(newName) + " is null"); // newName can be anything
        }
    }
}