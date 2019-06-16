using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTicketBookingSystem
{
    class Booking
    {
        public int Id { get; set; }

        public int By { get; set; }

        public int MovieId { get; set; }

        public DateTime TimeStamp { get; set; }

        public string[] BookedSeats { get; set; }

        public double Amount { get; set; }

        public int TheatreId { get; set; }

        public MovieSession ShowTime { get; set; }

        public int PaymentId { get; set; }



    }
}
