namespace MovieRental.PaymentProviders
{
    public interface IPaymentProviders
    {
        void Pay(double amount);
    }
}
