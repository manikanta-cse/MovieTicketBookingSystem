using System;

namespace MovieTicketBookingSystem.Payment
{
    class Payment
    {
        public int Id { get; set; }

        public PaymentType Type { get; set; }

        public string ReferenceId { get; set; }

        public PaymentStatus Status { get; set; }

        public decimal Value { get; set; }

        public Payment()
        {
            Id = new Random().Next();
        }
    }
}
