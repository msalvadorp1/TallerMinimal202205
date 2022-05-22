using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Applcations;
using Sol.TallerNet.ApiVentas.Repositories.Context;
using Sol.TallerNet.ApiVentas.Repositories.Operations;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TallerContext>(opt => {

    opt.UseSqlServer("Data Source=.;Initial Catalog=TallerNet;Integrated Security=True");
});

//Add dependencies
builder.Services.AddTransient<IArticuloRepository, ArticuloRepository>();
builder.Services.AddTransient<IArticuloApplication, ArticuloApplication>();
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

var summaries = new[]
{
    "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
};

app.MapGet("/weatherforecast", () =>
{
    var forecast = Enumerable.Range(1, 5).Select(index =>
        new WeatherForecast
        (
            DateTime.Now.AddDays(index),
            Random.Shared.Next(-20, 55),
            summaries[Random.Shared.Next(summaries.Length)]
        ))
        .ToArray();
    return forecast;
})
.WithName("GetWeatherForecast");


app.MapGet("/articulo", (IArticuloRepository articuloRepository, IArticuloApplication articuloApplication) =>
{
    string algo = articuloApplication.Get();
    return Results.Ok(articuloRepository.List());

});

app.Run();

internal record WeatherForecast(DateTime Date, int TemperatureC, string? Summary)
{
    public int TemperatureF => 32 + (int)(TemperatureC / 0.5556);
}