using MarvelQuiz.Application;
using SimpleInjector;

namespace MarvelQuiz.Web
{
    public class SimpleInjectorContainer
    {
        public static Container RegisterDependences()
        {
            var container = new Container();
            container.Register<IPersonagemAppService, PersonagemAppService>();
            container.Register<IUsuarioAppService, UsuarioAppService>();
            container.Verify();
            return container;
        }
    }
}
