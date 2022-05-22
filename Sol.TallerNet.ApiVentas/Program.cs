using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Applcations;
using Sol.TallerNet.ApiVentas.Repositories.Context;
using Sol.TallerNet.ApiVentas.Repositories.Operations;
using Sol.TallerNet.ApiVentas.Model.Extensions;
using Sol.TallerNet.ApiVentas.Model.Mappers;

var builder = WebApplication.CreateBuilder(args);


builder.Services.AddDbContext<TallerContext>(opt => {

    opt.UseSqlServer("Data Source=.;Initial Catalog=TallerNet;Integrated Security=True");
});


builder.Services.AddInjection();
builder.Services.AddAutoMapper(typeof(AutoMapperDto));
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
 
app.AddOperation();

app.Run();

 