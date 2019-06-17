using System;

namespace MovieTicketBookingSystem.Payment
{
    class PaymentProcesser
    {
        public Payment Process(decimal amount)
        {
            return new Payment
            {
               
                ReferenceId = Guid.NewGuid().ToString(), // from payment gateway
                Status = PaymentStatus.Paid, // from payment gateway
                Type = PaymentType.Credit,
                Value =amount
            

            };
        }

    }
}
