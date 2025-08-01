namespace MovieRental.CustomException;

public class InvalidPaymentMethodException : Exception
{
    public InvalidPaymentMethodException(string message) : base(message) { }
}
