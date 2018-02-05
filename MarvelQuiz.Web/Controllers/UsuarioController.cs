using MarvelQuiz.Application;
using MarvelQuiz.Domain.Entities;
using MarvelQuiz.Web.ViewModel;
using Newtonsoft.Json;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;

namespace MarvelQuiz.Web.Controllers
{
    public class UsuarioController: Controller
    {
        private readonly IUsuarioAppService _appService;

        public UsuarioController(IUsuarioAppService appService)
        {
            _appService = appService;
        }

        public ActionResult Post(string nomeUsuario, int pontuacao)
        {
            var response = _appService.Post(nomeUsuario, pontuacao);

            if (!response.IsSuccessStatusCode)
            {
                Response.StatusCode = (int) response.StatusCode;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.Content.ReadAsStringAsync().Result);
            }

            Response.StatusCode = (int)response.StatusCode; 
            return Content("");
        }

        public ActionResult Get()
        {
            var response = _appService.Get();
            var usuarios = JsonConvert.DeserializeObject<IEnumerable<Usuario>>(response.Content.ReadAsStringAsync().Result);
            return View("Ranking", usuarios.Select(usuario => new UsuarioViewModel(usuario)));
        }


    }
}