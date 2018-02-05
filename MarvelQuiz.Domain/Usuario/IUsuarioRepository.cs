using System.Collections.Generic;

namespace MarvelQuiz.Domain.Usuario
{
    public interface IUsuarioRepository
    {
        void Post(string nomeUsuario, int pontuacao);
        IEnumerable<Entities.Usuario> Get();
    }
}
