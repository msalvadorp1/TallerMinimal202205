using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Output;

namespace Sol.TallerNet.ApiVentas.Applcations.Operations
{
    public interface IUsuarioApplication
    {

        Task<UserAutenticaOutput> Login(UserAutenticaInput userAutenticaInput);

    }
}
