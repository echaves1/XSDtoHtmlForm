using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XSDtoHTML.Models
{
    public class GrupoMensagem
    {
        public string nome { get; set; }
        public List<Mensagem> mensagens { get; set; }

        public GrupoMensagem()
        {

        }

        public string ToString()
        {
            return this.nome;
        }
    }
}