using MarvelQuiz.Domain.Entities;

namespace MarvelQuiz.Web.ViewModel
{
    public class UsuarioViewModel
    {

        public UsuarioViewModel(Usuario usuario)
        {
            Nome = usuario.Nome;
            Pontuacao = usuario.Pontuacao;
        }

        public string Nome { get; set; }
        public int Pontuacao { get; set; }

    }
}