namespace MovieRental.Movie;

public interface IMovieRepository
{
    Task<Movie> SaveAsync(Movie rental);

    Task<List<Movie>> GetAll(int page, int pageSize);
}
