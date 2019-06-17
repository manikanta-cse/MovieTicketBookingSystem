using System;
using System.Collections.Generic;

namespace MovieTicketBookingSystem.Booking
{
    class Booking
    {
        public Guid Id { get; set; }

        public int By { get; set; }

        public int MovieId { get; set; }

        public DateTime TimeStamp { get; set; }
        public DateTime BookedDate { get; set; }

        public IEnumerable<int> BookedSeats { get; set; }

        public decimal Amount { get; set; }

        public int TheatreId { get; set; }

        public DateTime ShowTime { get; set; }

        public int PaymentId { get; set; }

        public Booking()
        {
            Id = Guid.NewGuid();
        }



    }
}
