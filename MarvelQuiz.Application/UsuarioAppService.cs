using System.Net.Http;

namespace MarvelQuiz.Application
{
    public class UsuarioAppService : BaseAppService, IUsuarioAppService
    {
        public HttpResponseMessage Post(string nomeUsuario, int pontuacao)
        {
           return PostRequest("http://localhost:6427/api/Usuario", new {nomeUsuario, pontuacao});
        }

        public HttpResponseMessage Get()
        {
            return GetRequest("http://localhost:6427/api/Usuario/");
        }
    }
}
