using Microsoft.AspNetCore.Authorization;
using Microsoft.IdentityModel.Tokens;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Output;
using Sol.TallerNet.ApiVentas.Applcations.Operations;
using Sol.TallerNet.ApiVentas.Model.Configs;
using Sol.TallerNet.ApiVentas.Repositories.Operations;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace Sol.TallerNet.ApiVentas.Model.Extensions
{
    public static class ExtensionCustom
    {
        /// <summary>
        /// Metodo usado para contar letras, etc etc
        /// </summary>
        /// <param name="cadena">Cadena a contar</param>
        /// <returns>Numero</returns>
        public static int ContarLetras(this string cadena)
        {

            int cant = cadena.Length;
            return cant;
        }

        public static IServiceCollection AddInjection(this IServiceCollection services)
        {


            //Add dependencies
            services.AddTransient<IArticuloRepository, ArticuloRepository>();
            services.AddTransient<IArticuloApplication, ArticuloApplication>();
            services.AddTransient<IUsuarioRepository, UsuarioRepository>();
            services.AddTransient<IUsuarioApplication, UsuarioApplication>();
            return services;
        }

        public static WebApplication AddOperation(this WebApplication app)
        {

            app.MapGet("/articulo", 
                [Authorize] 
                (IArticuloRepository articuloRepository, IArticuloApplication articuloApplication) =>
            {
                string algo = articuloApplication.Get();
                return Results.Ok(articuloRepository.List());

            });


            app.MapGet("/usuario", async (IUsuarioRepository usuarioRepository) =>
            {

                var res = await usuarioRepository.List();
                return Results.Ok(res);
            });

            app.MapPost("/user/autentica", async (IUsuarioApplication usuarioApplition, UserAutenticaInput user) =>
            {
                var res = await usuarioApplition.Login(user);
                return Results.Ok(res);
            });

            app.MapPost("/authv1", async (IConfiguration configuration, IUsuarioApplication usuarioApplition, UserAutenticaInput user) =>
            {
                var res = await usuarioApplition.Login(user);
                if (res == null)
                {
                    return Results.Unauthorized();
                }
                JwtParamConfig jwtParam = new JwtParamConfig();
                configuration.GetSection("JwtParam").Bind(jwtParam);


                //Paso1 crear la semilla
                byte[] bytes = System.Text.Encoding.ASCII.GetBytes(jwtParam.SecretKey);
                var securityKey = new SymmetricSecurityKey(bytes);

                //Paso2 clave simetrica
                var cred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

                //Paso3 crear claims
                var misClaims = new[] {
                    new Claim("Cod", res.Codigo.ToString()),
                    new Claim("Name", res.Nombre),
                    new Claim("Perfil", res.Perfil),
                    new Claim(JwtRegisteredClaimNames.Email, "jperez@gmail.com")
                };

                //Paso4 crear configurador de token
                JwtSecurityToken generador = new JwtSecurityToken(
                    expires: DateTime.Now.AddMinutes(jwtParam.ExpirationTime),
                    issuer: jwtParam.Issuer,
                    audience: jwtParam.Audience,
                    claims: misClaims,
                    signingCredentials: cred
                    );

                //Paso5 crear el token
                var handler = new JwtSecurityTokenHandler();
                string token1 = handler.WriteToken(generador);

                //var handler2 = new JwtSecurityTokenHandler();
                //string token2 = handler2.WriteToken(generador);

                UserAutenticaJwtOutput output = new UserAutenticaJwtOutput { 
                    Codigo = res.Codigo,
                    Token = token1
                };

                return Results.Ok(output);
            });


            return app;
        }
    }


    //public partial class ExtensionCustom { 

    //}
    //public class Extension2 : ExtensionCustom { 

    //}
}
