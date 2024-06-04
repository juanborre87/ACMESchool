namespace ACMESchool.Libraries.Application.Interfaces
{
    public interface IPaymentGateway
    {
        Task<bool> ProcessPayment(decimal amount);
    }
}