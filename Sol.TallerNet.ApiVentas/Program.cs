using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Applcations;
using Sol.TallerNet.ApiVentas.Repositories.Context;
using Sol.TallerNet.ApiVentas.Repositories.Operations;
using Sol.TallerNet.ApiVentas.Model.Extensions;
using Sol.TallerNet.ApiVentas.Model.Mappers;
using Sol.TallerNet.ApiVentas.Model.Configs;

var builder = WebApplication.CreateBuilder(args);

string rucParam = builder.Configuration.GetValue<string>("Ruc");
string cnnParam = builder.Configuration.GetValue<string>("ConnectionStrings:BdSql");
string cnnParam2 = builder.Configuration.GetConnectionString("BdSql");

JwtParamConfig jwtParam = new JwtParamConfig();
builder.Configuration.GetSection("JwtParam").Bind(jwtParam);

builder.Services.AddDbContext<TallerContext>(opt => {

    opt.UseSqlServer(cnnParam);
});



builder.Services.AddInjection();
builder.Services.AddAutoMapper(typeof(AutoMapperDto));
// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Compila Aplicar filtros o configuracion
var app = builder.Build();


// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.AddOperation();

app.Run();

 