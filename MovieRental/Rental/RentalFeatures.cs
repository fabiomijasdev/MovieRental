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
        try
        {
            IPaymentProviders payment = PaymentProvidersFactory.Create(rental.PaymentMethod);

            payment.Pay(rental.Amount);

            _logger.LogInformation("Successful payment");

            await _rentalRepository.SaveAsync(rental);

            return rental;

        }
        catch (Exception ex)
        {
            _logger.LogError(ex.Message);
            return await Task.FromException<Rental>(ex);
        }
    }

    //TODO: finish this method and create an endpoint for it
    public async Task<IEnumerable<Rental>> GetRentalsByCustomerNameAsync(string customerName)
    {
        return await _rentalRepository.GetRentalsByCustomerNameAsync(customerName);
    }

}
