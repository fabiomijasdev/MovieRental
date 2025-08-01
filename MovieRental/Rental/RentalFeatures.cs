namespace MovieRental.Rental;

public class RentalFeatures : IRentalFeatures
{
    private readonly IRentalRepository _rentalRepository;
    public RentalFeatures(IRentalRepository rentalRepository)
    {
        _rentalRepository = rentalRepository;
    }

    //Explanations:
    //Synchronous
    //Executes step by step, locking the thread.
    //Asynchronous
    //Releases the thread while waiting for I/O(such as database access).
    public async Task<Rental> SaveAsync(Rental rental)
    {
        await _rentalRepository.SaveAsync(rental);
        return rental;
    }

    //TODO: finish this method and create an endpoint for it
    public async Task<IEnumerable<Rental>> GetRentalsByCustomerNameAsync(string customerName)
    {
        return await _rentalRepository.GetRentalsByCustomerNameAsync(customerName);
    }

}
