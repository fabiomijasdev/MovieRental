using Microsoft.EntityFrameworkCore;
using MovieRental.Data;

namespace MovieRental.Movie;

public class MovieRepository : IMovieRepository
{
    private readonly MovieRentalDbContext _movieRentalDb;

    public MovieRepository(MovieRentalDbContext movieRentalDbContext)
    {
        _movieRentalDb = movieRentalDbContext;
    }

    public async Task<Movie> SaveAsync(Movie movie)
    {
        await _movieRentalDb.Movies.AddAsync(movie);
        await _movieRentalDb.SaveChangesAsync();
        return movie;
    }

    public async Task<IEnumerable<Movie>> GetAllAsyncWithPagination(int page, int pageSize)
    {
        return await _movieRentalDb.Movies
        .Skip((page - 1) * pageSize)
        .Take(pageSize).AsNoTracking()
        .ToListAsync();
    }
}
