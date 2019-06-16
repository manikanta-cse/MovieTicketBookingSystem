using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTicketBookingSystem.Payments
{
    class Payment
    {
        public int Id { get; set; }

        public PaymentType Type { get; set; }

        public string ReferenceId { get; set; }

        public PaymentStatus Status { get; set; }

        public decimal Value { get; set; }
    }
}
