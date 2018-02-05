using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MarvelQuiz.Web.ViewModel
{
    public class PersonagemViewModel
    {
        public int Id { get; set; }
        public bool Principal { get; set; }
        public string Nome { get; set; }
        public string Url { get; set; }
    }
}