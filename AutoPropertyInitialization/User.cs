using System;

namespace AutoPropertyInitialization
{
    // TAKE ONE
    public class User
    {
        // Test will fail until _id is set to new guid
        // Another way is to NOT have _id property, have protected set and set _id in a constructor
        private readonly Guid _id = Guid.NewGuid();

        private string _username = string.Empty;

        public Guid Id
        {
            get { return _id; }
        }

        public string Username
        {
            get { return _username; }

            protected set { _username = value; }
        }
    }

    // TAKE TWO - C# 6
    // no need for private id field and 
    public class User2
    {
        // protected set is not needed since it's initialized with NewGuid()
        public Guid Id { get; } = Guid.NewGuid();

        public string Username { get; protected set; } = string.Empty;
    }

    // NEW STUFF
    // Primary Constructors
    // no validation in constructor however
    public class User3
    {
        public struct User3(string username)
        {
            public string Username { get; protected set; } = username;
        }

        // protected set is not needed since it's initialized with NewGuid()
        public Guid Id { get; } = Guid.NewGuid();
    }

    // NEW STUFF
    // Explicit Constructors
    public class User4
    {
        public struct User3(string username, int num)
        {
            public string Username { get; protected set; } = username;
        }

        public User4(string username) : this(username, 5)
        {
            public string Username { get; protected set; } = username;
        }

        // protected set is not needed since it's initialized with NewGuid()
        public Guid Id { get; } = Guid.NewGuid();
    }
} 