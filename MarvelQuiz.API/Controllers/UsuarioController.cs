using MarvelQuiz.Domain.Usuario;
using System.Web.Http;

namespace MarvelQuiz.API.Controllers
{
    public class UsuarioController : ApiController
    {
        private readonly IUsuarioRepository _usuarioRepository;

        public UsuarioController(IUsuarioRepository usuarioRepository)
        {
            _usuarioRepository = usuarioRepository;
        }

        public IHttpActionResult Post(string nomeUsuario, int pontuacao)
        {
            _usuarioRepository.Post(nomeUsuario, pontuacao);
            return Ok();
        }

        public IHttpActionResult Get()
        {
            return Ok(_usuarioRepository.Get());
        }
    }
}
