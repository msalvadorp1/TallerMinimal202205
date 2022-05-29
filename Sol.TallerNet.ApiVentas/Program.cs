using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Applcations;
using Sol.TallerNet.ApiVentas.Repositories.Context;
using Sol.TallerNet.ApiVentas.Repositories.Operations;
using Sol.TallerNet.ApiVentas.Model.Extensions;
using Sol.TallerNet.ApiVentas.Model.Mappers;
using Sol.TallerNet.ApiVentas.Model.Configs;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
var builder = WebApplication.CreateBuilder(args);

string rucParam = builder.Configuration.GetValue<string>("Ruc");
string cnnParam = builder.Configuration.GetValue<string>("ConnectionStrings:BdSql");
string cnnParam2 = builder.Configuration.GetConnectionString("BdSql");

JwtParamConfig jwtParam = new JwtParamConfig();
builder.Configuration.GetSection("JwtParam").Bind(jwtParam);

byte[] bytes = System.Text.Encoding.ASCII.GetBytes(jwtParam.SecretKey);
var securityKey = new SymmetricSecurityKey(bytes);

//Autorizacion
builder.Services.AddAuthorization();
builder.Services.AddAuthentication
    (JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(opt => {
        opt.TokenValidationParameters = new TokenValidationParameters
        {
            ValidIssuer = jwtParam.Issuer,
            ValidAudience = jwtParam.Audience,
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateLifetime = true,
            IssuerSigningKey = securityKey
        };
    });

builder.Services.AddDbContext<TallerContext>(opt => {

    opt.UseSqlServer(cnnParam);
});



builder.Services.AddInjection();
builder.Services.AddAutoMapper(typeof(AutoMapperDto));
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

//Compila Aplicar filtros o configuracion
var app = builder.Build();

app.UseAuthentication();
app.UseAuthorization();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
 
app.AddOperation();

app.Run();

 