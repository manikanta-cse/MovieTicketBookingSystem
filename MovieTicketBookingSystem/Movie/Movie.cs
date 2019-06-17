using System;
using System.Collections.Generic;

namespace MovieTicketBookingSystem.Movie
{
    class Movie
    {
        public int Id { get; }

        public string Name { get; set; }

        public DateTime ReleasedDate { get; set; }

        public MovieStatus Status { get; set; }

        public Language Language { get; set; }

        public Genre Genre { get; set; }

        public int Rating { get; set; }

        public IEnumerable<Review> Reviews { get; set; }

        public Movie()
        {
            Id = new Random().Next();
        }

    }
}
