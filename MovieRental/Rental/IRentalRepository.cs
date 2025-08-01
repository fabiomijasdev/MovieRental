namespace MovieRental.Rental;

public interface IRentalRepository
{
    Task<Rental> SaveAsync(Rental rental);
    Task<IEnumerable<Rental>> GetRentalsByCustomerNameAsync(string customerName);
}
