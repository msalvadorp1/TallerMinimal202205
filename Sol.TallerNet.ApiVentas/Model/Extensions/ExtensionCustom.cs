using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Applcations.Operations;
using Sol.TallerNet.ApiVentas.Repositories.Operations;

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

            app.MapGet("/articulo", (IArticuloRepository articuloRepository, IArticuloApplication articuloApplication) =>
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
                var res =  await usuarioApplition.Login(user);
                return Results.Ok(res);
            });


            return app;
        }
    }


    //public partial class ExtensionCustom { 

    //}
    //public class Extension2 : ExtensionCustom { 

    //}
}
