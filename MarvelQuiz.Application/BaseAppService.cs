using Newtonsoft.Json;
using Newtonsoft.Json.Serialization;
using System;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net.Http.Headers;
using System.Web.Routing;

namespace MarvelQuiz.Application
{
    public class BaseAppService
    {
        private string _url;

        public HttpResponseMessage GetRequest(string url)
        {
            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(url);
            return client.GetAsync(client.BaseAddress).Result;
        }

        public HttpResponseMessage PostRequest(string url, object parametros)
        {
            _url = url;
            AddParameters(parametros);

            var client = new HttpClient();
            client.DefaultRequestHeaders.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            client.BaseAddress = new Uri(_url);

            return client.PostAsync(client.BaseAddress, string.Empty, new JsonMediaTypeFormatter
            {
                SerializerSettings = new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Include,
                    ReferenceLoopHandling = ReferenceLoopHandling.Ignore,
                    ContractResolver = new DefaultContractResolver { IgnoreSerializableAttribute = false }
                }
            }).Result;
        }

        public HttpResponseMessage PutRequest()
        {
            return new HttpResponseMessage();
        }

        public HttpResponseMessage DeleRequest()
        {
            return new HttpResponseMessage();
        }

        private void AddParameters(object parametros)
        {
            if(parametros == null)
                return;

            _url += "?";

            foreach (var parametro in new RouteValueDictionary(parametros))
                _url += $"{parametro.Key}={parametro.Value}&";
        }
    }
}
