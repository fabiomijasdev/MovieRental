using MovieRental.Configuration;
using MovieRental.Data;
using MovieRental.Middlewares;
using MovieRental.Movie;
using MovieRental.Rental;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddEntityFrameworkSqlite().AddDbContext<MovieRentalDbContext>();

//1º Throwing an error when we start

//builder.Services.AddSingleton<IRentalFeatures, RentalFeatures>();

//why?
//It means that we are trying to inject a service with Scoped lifetime (in this case, MovieRentalDbContext)
//inside a service with Singleton lifetime (IRentalFeatures), which is not allowed in ASP.NET Core.

//fix
//builder.Services.AddScoped<IRentalFeatures, RentalFeatures>();

builder.Services.AddFeaturesServices();
builder.Services.AddRepositoryServices();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

using (var client = new MovieRentalDbContext())
{
    client.Database.EnsureCreated();
}

app.UseMiddleware<ExceptionHandlingMiddleware>();

app.Run();
