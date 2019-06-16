using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTicketBookingSystem
{
    class UserRequest
    {
        public int UserId { get; set; }

        public int MovieId { get; set; }

        public int TheatreId { get; set; }

        public int RequestedSeats { get; set; }

        public DateTime ShowDateTime { get; set; }

        public DateTime BookedDate { get; set; }
    }
}
