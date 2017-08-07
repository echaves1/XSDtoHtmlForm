using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace XSDtoHTML.Models
{
    public class Mensagem
    {
        public string nome { get; set; }
        public string xml { get; set; }
        public string html { get; set; }

        public Mensagem()
        {

        }

        public string ToString()
        {
            return this.nome;
        }
    }
}