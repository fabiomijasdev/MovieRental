using MovieRental.Customer;
using MovieRental.Movie;
using MovieRental.Rental;

namespace MovieRental.Configuration
{
    public static class DependencyIntection
    {
        public static IServiceCollection AddFeaturesServices(this IServiceCollection services)
        {
            services.AddScoped<IRentalFeatures, RentalFeatures>();

            services.AddScoped<IMovieFeatures, MovieFeatures>();

            services.AddScoped<ICustomerFeatures, CustomerFeatures>();

            return services;
        }


        public static IServiceCollection AddRepositoryServices(this IServiceCollection services)
        {
            services.AddScoped<IMovieRepository, MovieRepository>();

            services.AddScoped<IRentalRepository, RentalRepository>();

            services.AddScoped<ICustomerRepository, CustomerRepository>();

            return services;
        }

    }
}
