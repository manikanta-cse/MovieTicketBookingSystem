using System;
using System.Collections.Generic;
using System.Text;

namespace MovieTicketBookingSystem.Payments
{
    class PaymentProcesser
    {
        public Payment Process(decimal amount)
        {
            return new Payment
            {
                Id = new Random().Next(),
                ReferenceId = Guid.NewGuid().ToString(), // from payment gateway
                Status = PaymentStatus.PAID, // from payment gateway
                Type = PaymentType.CREDIT,
                Value =amount
            

            };
        }

    }
}
