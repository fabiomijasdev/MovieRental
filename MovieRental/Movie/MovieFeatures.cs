namespace MovieRental.Movie;

public class MovieFeatures : IMovieFeatures
{
    private readonly IMovieRepository _movieRepository;
    public MovieFeatures(IMovieRepository movieRepository)
    {
        _movieRepository = movieRepository;
    }

    // TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?

    //Lack of abstraction/coupling with Entity Framework
    //Performance issues with large sets
    //Lack of error handling
    // There is no try-catch. If there is a connection error or EF failure, an exception will be thrown and isn't  handled in higher layers.
    //public List<Movie> GetAll()
    //{
    //    return _movieRentalDb.Movies.ToList();
    //}

    public async Task<IEnumerable<Movie>> GetAllAsyncWithPagination(int page, int pageSize)
    {
        return await _movieRepository.GetAllAsyncWithPagination(page, pageSize);
    }

    public async Task<Movie> SaveAsync(Movie movie)
    {
        await _movieRepository.SaveAsync(movie);

        return movie;
    }

}
