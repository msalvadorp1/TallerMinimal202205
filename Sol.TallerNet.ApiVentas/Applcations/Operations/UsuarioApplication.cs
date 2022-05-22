using AutoMapper;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Input;
using Sol.TallerNet.ApiVentas.Applcations.Dtos.Output;
using Sol.TallerNet.ApiVentas.Repositories.Entities;
using Sol.TallerNet.ApiVentas.Repositories.Operations;

namespace Sol.TallerNet.ApiVentas.Applcations.Operations
{
    public class UsuarioApplication : IUsuarioApplication
    {
        private readonly IUsuarioRepository usuarioRepository;
        private readonly ILogger<UsuarioApplication> logger;
        private readonly IMapper mapper;

        public UsuarioApplication(
            IUsuarioRepository usuarioRepository,
            ILogger<UsuarioApplication> logger,
            IMapper mapper)
        {
            this.usuarioRepository = usuarioRepository;
            this.logger = logger;
            this.mapper = mapper;
        }
        public async Task<UserAutenticaOutput> Login(UserAutenticaInput userAutenticaInput)
        {
            Usuario user = await usuarioRepository.Autentica(userAutenticaInput.CodUsuario, userAutenticaInput.Clave);

            UserAutenticaOutput res = mapper.Map<UserAutenticaOutput>(user);

            //UserAutenticaOutput res = new UserAutenticaOutput();
            //res.Credencial = user.Credenciales;
            //res.Codigo = user.IdUsuario;
            
           return res;
        }
    }
}
