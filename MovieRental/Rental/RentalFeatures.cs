using MovieRental.CustomException;
using MovieRental.Middlewares;
using MovieRental.PaymentProviders;
using SQLitePCL;

namespace MovieRental.Rental;

public class RentalFeatures : IRentalFeatures
{
    private readonly IRentalRepository _rentalRepository;
    private readonly ILogger<RentalFeatures> _logger;
    public RentalFeatures(IRentalRepository rentalRepository, ILogger<RentalFeatures> logger)
    {
        _rentalRepository = rentalRepository;
        _logger = logger;
    }

    //Explanations:
    //Synchronous
    //Executes step by step, locking the thread.
    //Asynchronous
    //Releases the thread while waiting for I/O(such as database access).
    public async Task<Rental> SaveAsync(Rental rental)
    {
        IPaymentProviders payment = PaymentProvidersFactory.Create(rental.PaymentMethod);

        if (rental.Amount <= 0)
            throw new PaymentFailedException($"The Amount must be greater than zero, but we have {rental.Amount} ");

        payment.Pay(rental.Amount);

        _logger.LogInformation("Successful payment");

        await _rentalRepository.AddAsync(rental);

        return rental;
    }

    //TODO: finish this method and create an endpoint for it
    public async Task<IEnumerable<Rental>> GetRentalsByCustomerNameAsync(string customerName)
    {
        return await _rentalRepository.GetRentalsByCustomerNameAsync(customerName);
    }

}
