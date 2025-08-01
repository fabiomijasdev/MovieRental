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
                    throw new NotSupportedException($"{paymentMethod} is not curremtly supported as a payment method.");
            }
        }
    }
}
