namespace MovieRental.CustomException;

public class PaymentFailedException : Exception
{
    public PaymentFailedException(string message) : base(message) { }
}
