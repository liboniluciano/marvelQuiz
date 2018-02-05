using MarvelQuiz.Application;
using MarvelQuiz.Web.ViewModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Web.Mvc;

namespace MarvelQuiz.Web.Controllers
{
    public class PersonagemController : Controller
    {
        private readonly IPersonagemAppService _appService;

        public PersonagemController(IPersonagemAppService appService)
        {
            _appService = appService;
        }

        // GET: Personagem
        public ActionResult Get()
        {
            var response = _appService.Get();
            if (!response.IsSuccessStatusCode)
            {
                Response.StatusCode = (int)response.StatusCode;
                Response.TrySkipIisCustomErrors = true;
                return Content(response.Content.ReadAsStringAsync().Result);
            }

            dynamic json = JsonConvert.DeserializeObject(response.Content.ReadAsStringAsync().Result);

            var personagens = new List<PersonagemViewModel>();

            for (var i = 0; i < 4; i++)
            {
                var person = json.data.results[i];

                personagens.Add(new PersonagemViewModel
                {
                    Nome = person.name,
                    Url = $"{person.thumbnail.path}.{person.thumbnail.extension}",
                    Id = person.id
                });
            }

            if (personagens.All(x => x.Url.Contains("image_not_available")) || personagens.All(x => x.Url.Contains("4c002e0305708")))
                return Get();

            var personagensValidos = personagens.Where(x => !x.Url.Contains("image_not_available")).ToList();
            var indexRandom = new Random().Next(0, personagensValidos.Count);
            var personagemValido = personagensValidos[indexRandom];
            personagens.First(x => x.Id == personagemValido.Id).Principal = true;

            Session["IdPersonagemPrincipal"] = personagemValido.Id;
            return View("Personagem", personagens);
        }

        public ActionResult VerificaResposta(int idPersonagem)
        {
            try
            {
                Response.StatusCode = (int) HttpStatusCode.OK;
                return Content(idPersonagem == (int) Session["IdPersonagemPrincipal"] ? "1" : "0");
            }
            catch (Exception ex)
            {
                Response.StatusCode = (int) HttpStatusCode.InternalServerError;
                return Content($"Erro ao verificar a resposta: {ex.Message}");
            }
        }
    }
}