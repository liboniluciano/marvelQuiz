using System.Web.Http;

namespace MarvelQuiz.API.Controllers
{
    public class PingController: ApiController
    {
        public IHttpActionResult Get()
        {
            return Ok("Api Ok");
        }
    }
}