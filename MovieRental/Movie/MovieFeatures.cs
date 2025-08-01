using System;
using Microsoft.EntityFrameworkCore;
using MovieRental.Data;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace MovieRental.Movie
{
	public class MovieFeatures : IMovieFeatures
	{
		private readonly MovieRentalDbContext _movieRentalDb;
		public MovieFeatures(MovieRentalDbContext movieRentalDb)
		{
			_movieRentalDb = movieRentalDb;
		}
		
		public Movie Save(Movie movie)
		{
			_movieRentalDb.Movies.Add(movie);
			_movieRentalDb.SaveChanges();
			return movie;
		}

        // TODO: tell us what is wrong in this method? Forget about the async, what other concerns do you have?

        //Lack of abstraction/coupling with Entity Framework
        //Performance issues with large sets
        //Lack of error handling
        // There is no try-catch. If there is a connection error or EF failure, an exception will be thrown and isn't  handled in higher layers.
        public List<Movie> GetAll()
		{
			return _movieRentalDb.Movies.ToList();
		}


	}
}
