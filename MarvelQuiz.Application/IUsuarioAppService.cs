using System.Net.Http;

namespace MarvelQuiz.Application
{
    public interface IUsuarioAppService
    {
        HttpResponseMessage Post(string nomeUsuario, int pontuacao);
        HttpResponseMessage Get();
    }
}
