using System;

namespace MovieTicketBookingSystem.User
{
    class User
    {
        public int Id { get; private set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public int Mobile { get; set; }

        public User()
        {
            Id = new Random().Next();
        }
        
    }
}
