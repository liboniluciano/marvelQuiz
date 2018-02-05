using MarvelQuiz.Domain.Usuario;
using MarvelQuiz.Repository;
using MarvelQuiz.Repository.DataBase;
using SimpleInjector;

namespace MarvelQuiz.API
{
    public static class SimpleInjectorContainer
    {
        public static Container RegisterDependences()
        {
            var container = new Container();
            container.Register<IUsuarioRepository, UsuarioRepository>();
            container.Register<IDataBase, DataBase>();
            container.Verify();
            return container;
        }
    }
}