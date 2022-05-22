using Microsoft.EntityFrameworkCore;
using Sol.TallerNet.ApiVentas.Repositories.Context;
using Sol.TallerNet.ApiVentas.Repositories.Entities;

namespace Sol.TallerNet.ApiVentas.Repositories.Operations
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly TallerContext tallerContext;

        public UsuarioRepository(TallerContext tallerContext)
        {
            this.tallerContext = tallerContext;
        }

        public async Task<Usuario> Autentica(string credencial, string clave)
        {
            var res = await (from x in tallerContext.Usuario
                    where x.Credenciales == credencial
                    && x.Password == clave
                    select x).FirstOrDefaultAsync();

            return res;
        }

        public Task Delete(int id)
        {
            throw new NotImplementedException();
        }

        public Task<Usuario> Get(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Usuario>> List()
        {
            var list = await tallerContext.Usuario.ToListAsync();
            return list;
        }

        public Task<Usuario> Update(Usuario usuario)
        {
            throw new NotImplementedException();
        }
    }
}
