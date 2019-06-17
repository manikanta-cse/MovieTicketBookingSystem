using System;
using MovieTicketBookingSystem.Payment;
using MovieTicketBookingSystem.User;

namespace MovieTicketBookingSystem.Booking
{
    class BookingManager
    {
        private readonly Theatre.Theatre _theatre;
        private readonly PaymentProcesser _paymentProcesser;
        public BookingManager(Theatre.Theatre theatre, PaymentProcesser paymentProcesser)
        {
            _theatre = theatre;
            _paymentProcesser = paymentProcesser;
        }

        public Booking ProcessBooking(UserRequest userRequest)
        {
            var bookedSeats = _theatre.BookSeats(userRequest.RequestedSeats,userRequest.ShowDateTime.TimeOfDay);

            var payment = _paymentProcesser.Process(_theatre.SeatPrice * userRequest.RequestedSeats);

            return new Booking
            {
                Amount =  payment.Value,
                BookedSeats = bookedSeats,
                By = userRequest.UserId,
                MovieId = userRequest.MovieId,
                PaymentId = payment.Id,
                ShowTime = userRequest.ShowDateTime,
                TheatreId = userRequest.TheatreId,
                BookedDate = DateTime.Now

            };
        }
    }
}
