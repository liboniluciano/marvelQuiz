using MarvelQuiz.Domain.Entities;
using MarvelQuiz.Domain.Usuario;
using MarvelQuiz.Repository.DataBase;
using System.Collections.Generic;

namespace MarvelQuiz.Repository
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly IDataBase _db;

        private enum Procedures
        {
            MarvelQuiz_InsPontuacao,
            MarvelQuiz_SelRanking
        }

        public UsuarioRepository(IDataBase dataBase)
        {
            _db = dataBase;
        }

        public void Post(string nomeUsuario, int pontuacao)
        {
            _db.ExecuteProcedure(Procedures.MarvelQuiz_InsPontuacao);
            _db.AddParameter("@Nome", nomeUsuario);
            _db.AddParameter("@Pontuacao", pontuacao);
            _db.ExecuteNonQuery();
        }

        public IEnumerable<Usuario> Get()
        {
            _db.ExecuteProcedure(Procedures.MarvelQuiz_SelRanking);
            var usuarios = new List<Usuario>();

            using (var reader = _db.ExecuteReader())
            {
                while (reader.Read())
                {
                    usuarios.Add(new Usuario
                    {
                        Nome = reader.ReadAttr<string>("Nome"),
                        Pontuacao = reader.ReadAttr<int>("Pontuacao")
                    });
                }
            }
            return usuarios;
        }
    }
}
