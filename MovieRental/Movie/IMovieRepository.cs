namespace MovieRental.Movie;

public interface IMovieRepository
{
    Task<Movie> SaveAsync(Movie rental);

    Task<IEnumerable<Movie>> GetAllAsyncWithPagination(int page, int pageSize);
}
