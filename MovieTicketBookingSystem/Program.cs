using System;
using System.Collections.Generic;
using MovieTicketBookingSystem.Booking;
using MovieTicketBookingSystem.Movie;
using MovieTicketBookingSystem.Payment;
using MovieTicketBookingSystem.Theatre;
using MovieTicketBookingSystem.User;

namespace MovieTicketBookingSystem
{
    class Program
    {
        static void Main(string[] args)
        {


            var movie = new Movie.Movie()
            {
                Genre = Genre.Comedy,
                Language = Language.Telugu,
                Name = "I dont know",
                Rating = 3,
                ReleasedDate = DateTime.Now,
                Status = MovieStatus.Playing
            };


            var showTimings = new List<TimeSpan>()
            {
                new TimeSpan(10,30,0),
                new TimeSpan(14,20,0)
            };
            var theatre = new Theatre.Theatre(showTimings, SeatLayout.Basic,100)
            {
                PlayingNow = movie,
                Name = "My theatre"
            };

            Console.WriteLine($"Currently palying {theatre.PlayingNow.Name} in {theatre.Name} ");
            Console.WriteLine("Available show timings are : ");
            for (int i = 0; i < theatre.ShowTimings.Count; i++)
            {
                Console.WriteLine($"{i+1} - {showTimings[i]} ");
            }

            Console.WriteLine("Select a show you wish to book");

            var userSeletedshow = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine($"You've selected {showTimings[userSeletedshow-1]} show");

            Console.WriteLine("How many seats you need ?");
            var seatsRequested = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine($"You have choosen {seatsRequested} seats");
            

            Console.WriteLine("Press 'Y' to proceed with booking");
            var userAcceptance = Console.ReadKey().Key;

            if (userAcceptance != ConsoleKey.Y)
            {
                return;
            }

            var selectedShow = showTimings[userSeletedshow - 1];

            var bookingManager = new BookingManager(theatre, new PaymentProcesser());

            var booking = bookingManager.ProcessBooking(new UserRequest
            {
                MovieId = theatre.PlayingNow.Id,
                RequestedSeats = seatsRequested,
                ShowDateTime = new DateTime(2018, 6, 20,selectedShow.Hours,selectedShow.Minutes,selectedShow.Seconds),
                TheatreId = theatre.Id,
                UserId = 1


            });


            Console.WriteLine("\nCongrats your ticket has been booked !");
            Console.WriteLine("Below are the details");
            Console.WriteLine($" Booking Id :{booking.Id}" +
                              $"\n Movie : {booking.MovieId} " +
                              $"\n Amount : {booking.Amount} " +
                              $"\n Date: {booking.BookedDate}" +
                              $"\n Payment Id: {booking.PaymentId}" +
                              $"\n ShowTime: {booking.ShowTime}" +
                              $"\n Theatre: {booking.TheatreId}");
                            

            Console.ReadKey();
        }
    }
}
