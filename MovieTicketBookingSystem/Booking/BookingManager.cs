using MovieTicketBookingSystem.Payments;
using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTicketBookingSystem
{
    class BookingManager
    {
        private readonly Theatre _theatre;
        private readonly PaymentProcesser _paymentProcesser;
        public BookingManager(Theatre theatre, PaymentProcesser paymentProcesser)
        {
            _theatre = theatre;
            _paymentProcesser = paymentProcesser;
        }

        public Booking ProcessBooking(UserRequest userRequest)
        {
            var bookedSeats = _theatre.BookSeats(userRequest.RequestedSeats,userRequest.ShowDateTime.TimeOfDay);

            var payment = _paymentProcesser.Process(_theatre.SeatPrice + userRequest.RequestedSeats);

            return new Booking
            {
                Amount = _theatre.SeatPrice + userRequest.RequestedSeats,
                BookedSeats = bookedSeats,
                By = userRequest.UserId,
                Id = Guid.NewGuid(),
                MovieId = userRequest.MovieId,
                PaymentId = payment.Id,
                ShowTime = userRequest.ShowDateTime,
                TheatreId = userRequest.TheatreId,
                BookedDate = DateTime.Now

            };
        }
    }
}
