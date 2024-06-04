using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ACMESchool.Libraries.Application.Interfaces;

namespace ACMESchool.Libraries.Infrastructure.Services
{
    public class PaymentGatewayService : IPaymentGateway
    {
        public PaymentGatewayService()
        { }

        public async Task<bool> ProcessPayment(decimal amount)
        {
            // Implementation to process payment
            throw new NotImplementedException();
        }
    }
}
