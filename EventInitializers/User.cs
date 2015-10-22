using System;

namespace EventInitializers
{
    public class User
    {
        public string Name { get; set; }

        public event EventHandler<EventArgs> Speaking;

        public void Speak()
        {
            // Check for listeners
            if (Speaking != null)
            {
                Speaking(this, new EventArgs());
            }
        }
    }
}
