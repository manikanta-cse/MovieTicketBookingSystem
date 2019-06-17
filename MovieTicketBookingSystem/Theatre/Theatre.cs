using System;
using System.Collections.Generic;
using System.Linq;

namespace MovieTicketBookingSystem.Theatre
{
    internal class Theatre
    {
        public int Id { get; private set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<TimeSpan> ShowTimings { get; private set; }

        public Movie.Movie PlayingNow { get; set; }
        public SeatLayout SeatingCapacity { get; set; }

        public decimal SeatPrice { get; private set; }

        private Dictionary<TimeSpan, List<int>> _availableSeats;

        public Theatre(List<TimeSpan> showTimings, SeatLayout seatingCapacity, decimal seatPrice)
        {
            ShowTimings = showTimings;
            SeatingCapacity = seatingCapacity;
            SeatPrice = seatPrice;
            Id = new Random().Next();
            GenerateSeatsForAllShows();
        }

        public IEnumerable<int> BookSeats(int requestedSeats,TimeSpan showTime)
        {
            var bookedSeats = new List<int>();
            
            var totalSeats = _availableSeats.FirstOrDefault(st => st.Key == showTime && st.Value.Count >= requestedSeats);

            if(totalSeats.Value.Count> requestedSeats)
            {
                bookedSeats = totalSeats.Value.TakeLast(requestedSeats).ToList();
                foreach (var seat in bookedSeats)
                {
                    totalSeats.Value.Remove(seat);
                }
            }

            return bookedSeats;
        }

        public void CancelSeats(IEnumerable<int> cancelledSeats, TimeSpan showTime)
        {
            var availableSeats = _availableSeats.FirstOrDefault(st => st.Key == showTime);

            availableSeats.Value.AddRange(cancelledSeats);

        }

        public decimal GetSeatPrice()
        {
            return SeatPrice;
        }

        public void GenerateSeatsForAllShows()
        {
            _availableSeats = new Dictionary<TimeSpan, List<int>>();

            foreach (var show in ShowTimings)
            {
                _availableSeats.Add( show, Enumerable.Range(1, Convert.ToInt32(SeatingCapacity)).ToList());
            }
        }
    }
}
