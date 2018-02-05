using System;
using System.Net.Http;
using System.Security.Cryptography;
using System.Text;

namespace MarvelQuiz.Application
{
    public class PersonagemAppService : BaseAppService, IPersonagemAppService
    {
        public HttpResponseMessage Get()
        {
            var offSetValue = new Random().Next(1, 1488);
            return GetRequest($"https://gateway.marvel.com:443/v1/public/characters?orderBy=modified&limit=4&offset={offSetValue}&{GetParametrosAutenticacao()}");
        }

        private string GetParametrosAutenticacao()
        {
            // Parâmetros de autenticação da API
            const string publicKey = "9caa4c6bf038f2c2001929265ac27f46";
            const string privateKey = "090ae573e0c352440b2538ce523dcf4aed6ff504";
            var ts = DateTime.Now.ToString("yyyyMMddHHmmssffff");

            //Geração do hash através dos parâmetros
            var bytes = Encoding.UTF8.GetBytes(ts + privateKey + publicKey);
            var bytesHash = MD5.Create().ComputeHash(bytes);
            var hash = BitConverter.ToString(bytesHash).ToLower().Replace("-", string.Empty);

            return $"ts={ts}&apikey={publicKey}&hash={hash}";
        }
    }
}
