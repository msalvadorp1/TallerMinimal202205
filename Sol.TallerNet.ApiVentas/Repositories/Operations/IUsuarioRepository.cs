using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Operations
{
    public interface IUsuarioRepository
    {
        Task<List<Usuario>> List();
        Task<Usuario> Get(int id);
        Task<Usuario> Update(Usuario usuario);
        Task Delete(int id);
        Task<Usuario> Autentica(string credencial, string clave);
    }
}
