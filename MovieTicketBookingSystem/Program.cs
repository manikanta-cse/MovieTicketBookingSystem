using System;

namespace MovieTicketBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {



            var showTimings = new System.Collections.Generic.List<TimeSpan>()
            {
                new TimeSpan(10,30,0),
                new TimeSpan(14,20,0)
            };
            var theatre = new Theatre(showTimings, Theatres.SeatLayout.Basic);


            var bookingManager = new BookingManager(theatre, new Payments.PaymentProcesser());
            var booking = bookingManager.ProcessBooking(new UserRequest
            {
                MovieId = 1,
                RequestedSeats = 2,
                ShowDateTime = new DateTime(2018, 6, 20, 10, 30, 0),
                TheatreId = 1,
                UserId = 1


            });

            Console.WriteLine(booking);

            Console.ReadKey();
        }
    }
}
