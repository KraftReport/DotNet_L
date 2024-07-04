using Microsoft.EntityFrameworkCore;
using Pokemon;
using Pokemon.Data;
using Pokemon.Interfaces;
using Pokemon.Repositories;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
builder.Services.AddHttpClient("jokes", x =>
{
    x.BaseAddress = new Uri("https://localhost:7071/");
});
builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddScoped<IPokemonRepository, PokemonRepository>();
builder.Services.AddScoped<IReviewRepository, ReviewRepository>();
builder.Services.AddScoped<IOwnerRepositroy,OwnerRepository>();
builder.Services.AddScoped<ICategoryRepository,CategoryRepository>();
builder.Services.AddScoped<ICountryRepository, CountryRepository>();
builder.Services.AddScoped<IReviewerRepository, ReviewerRepository>();
builder.Services.AddScoped<IReviewRepository,ReviewRepository>();
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

// Register the Seed class with the dependency injection container
builder.Services.AddTransient<Seed>();

var app = builder.Build();

if (args.Length == 1 && args[0].ToLower() == "seeddata")
{
    SeedData(app);
}

void SeedData(IHost app)
{
    using (var scope = app.Services.CreateScope())
    {
        var service = scope.ServiceProvider.GetRequiredService<Seed>();
        service.SeedDataContext();
    }
}

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
