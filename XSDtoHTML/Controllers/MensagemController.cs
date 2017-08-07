using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using XSDtoHTML.Models;
using XSDtoHTML.Providers;

namespace XSDtoHTML.Controllers
{
    public class MensagemController : ApiController
    {
        [HttpGet]
        [Route("api/Mensagem")]
        public List<GrupoMensagem> getGrupos()
        {
            MensagemProvider provider = new MensagemProvider();
            var grupos = provider.retornaSomenteGrupos();
            return grupos;
        }

        [HttpGet]
        [Route("api/GruposPreenchidos")]
        public List<GrupoMensagem> GruposPreenchidos()
        {
            MensagemProvider provider = new MensagemProvider();
            var grupos = provider.retornaGrupos();
            return grupos;
        }

        [HttpGet]
        [Route("api/MensagensDoGrupo")]
        public List<Mensagem> MensagensDoGrupo(string grupo)
        {
            MensagemProvider provider = new MensagemProvider();
            GrupoMensagem grupoMensagem = JsonConvert.DeserializeObject<GrupoMensagem>(grupo);

            var mensagens = provider.MensagensDoGrupo(grupoMensagem.nome.Replace(@"/",""));
            /*for (int i =0; i< mensagens.Count; i++)
            {
                mensagens[i].html = "";
            }*/
            return mensagens;
        }

    }
}
