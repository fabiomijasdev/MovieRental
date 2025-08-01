using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using MovieRental.PaymentProviders;
using Swashbuckle.AspNetCore.Annotations;

namespace MovieRental.Rental
{
    public class Rental
    {
        [Key]
        public int Id { get; set; }
        public int DaysRented { get; set; }

        public double Amount { get; set; }

        public PaymentMethod PaymentMethod { get; set; }

        [SwaggerIgnore]
        public Movie.Movie? Movie { get; set; }

        [ForeignKey("Movie")]
        public int MovieId { get; set; }

        [SwaggerIgnore]
        public Customer.Customer? Customer { get; set; }

        [ForeignKey("Customer")]
        public int CustomerId { get; set; }
    }
}
