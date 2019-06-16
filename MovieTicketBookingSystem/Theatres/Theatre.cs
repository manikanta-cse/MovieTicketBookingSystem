using MovieTicketBookingSystem.Theatres;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MovieTicketBookingSystem
{
    internal class Theatre
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Address { get; set; }

        public List<TimeSpan> ShowTimings { get; private set; }

        public Movie PlayingNow { get; set; }
        public SeatLayout SeatingCapacity { get; set; }

        public decimal SeatPrice { get; set; }

        public int FilledSeats { get; set; }
        public int RemainingSeats { get; set; }

        public Dictionary<TimeSpan, List<int>> AvailableSeats { get; set; }

        public Theatre(List<TimeSpan> showTimings, SeatLayout seatingCapacity)
        {
            ShowTimings = showTimings;
            SeatingCapacity = seatingCapacity;
            RemainingSeats = Convert.ToInt32(SeatingCapacity);
            GenerateSeatsForAllShows();
        }

        public IEnumerable<int> BookSeats(int requestedSeats,TimeSpan showTime)
        {
            RemainingSeats -= requestedSeats;
            FilledSeats += requestedSeats;

            var bookedSeats = new List<int>();
            
            var totalSeats = AvailableSeats.FirstOrDefault(st => st.Key == showTime);

            if(totalSeats.Value.Count> requestedSeats)
            {
                 bookedSeats = totalSeats.Value.TakeLast(requestedSeats).ToList();
                for (int i = 0; i < bookedSeats.Count; i++)
                {
                    totalSeats.Value.Remove(bookedSeats[i]);
                }               
                
            }


            return bookedSeats;
        }

        public void CancelSeats(IEnumerable<int> cancelledSeats, TimeSpan showTime)
        {
            var totalSeats = AvailableSeats.FirstOrDefault(st => st.Key == showTime);

            if(totalSeats.Value.Count == RemainingSeats)
            {
                return;
            }

            totalSeats.Value.AddRange(cancelledSeats);

            RemainingSeats += cancelledSeats.ToList().Count;
            FilledSeats -= cancelledSeats.ToList().Count;

        }

        public decimal GetSeatPrice()
        {
            return SeatPrice;
        }

        public void GenerateSeatsForAllShows()
        {
            AvailableSeats = new Dictionary<TimeSpan, List<int>>();
            
            for (int i = 0; i < ShowTimings.Count; i++)
            {
                AvailableSeats.Add( ShowTimings[i], Enumerable.Range(1, Convert.ToInt32(SeatingCapacity)).ToList());
                
            }    


        }
    }
}
