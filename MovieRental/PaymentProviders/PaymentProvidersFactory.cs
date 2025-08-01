using MovieRental.CustomException;

namespace MovieRental.PaymentProviders
{
    public class PaymentProvidersFactory
    {
        public static IPaymentProviders Create(PaymentMethod paymentMethod)
        {
            switch (paymentMethod)
            {
                case PaymentMethod.MbWay:
                    return new MbWayProvider();

                case PaymentMethod.PayPal:
                    return new PayPalProvider();

                case PaymentMethod.CreditCard:
                    return new CreditCardProvider();

                default:
                    throw new InvalidPaymentMethodException($"{paymentMethod} is not curremtly supported as a payment method.");                    
            }
        }
    }
}
