using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTicketBookingSystem
{
    internal class Theatre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public MovieSession ShowTimings { get; set; }

        public Movie PlayingNow { get; set; }
        public Theatres.SeatLayout Seating { get; set; }

        public int FilledSeats { get; set; }
        public int RemaingSeats { get; set; }
    }
}
