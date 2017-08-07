using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using XSDtoHTML.Providers;

namespace XSDtoHTML.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Pagina Inicial";
            ViewBag.MensagemForm = "<form> <br><fieldset> <legend>BCMSG</legend> </br><label>IdentdEmissor<label/><input type='text' value=IdentdEmissor'/></br><label>IdentdDestinatario<label/><input type='text' value=IdentdDestinatario'/></br><label>IdentdContg<label/><input type='text' value=IdentdContg'/></br><label>IdentdOperad<label/><input type='text' value=IdentdOperad'/></br><label>IdentdOperadConfc<label/><input type='text' value=IdentdOperadConfc'/></br><fieldset> <legend>Grupo_Seq</legend> </br><label>NumSeq<label/><input type='text' value=NumSeq'/></br><label>IndrCont<label/><input type='text' value=IndrCont'/></br></fieldset><label>DomSist<label/><input type='text' value=DomSist'/></br><label>NUOp<label/><input type='text' value=NUOp'/></br></fieldset><fieldset> <legend>SISMSG</legend> </br><fieldset> <legend>STR0004</legend> </br><label>CodMsg<label/><input type='text' value=CodMsg'/></br><label>NumCtrlIF<label/><input type='text' value=NumCtrlIF'/></br><label>ISPBIFDebtd<label/><input type='text' value=ISPBIFDebtd'/></br><label>ISPBIFCredtd<label/><input type='text' value=ISPBIFCredtd'/></br><label>AgCredtd<label/><input type='text' value=AgCredtd'/></br><label>FinlddIF<label/><input type='text' value=FinlddIF'/></br><label>CodIdentdTransf<label/><input type='text' value=CodIdentdTransf'/></br><label>VlrLanc<label/><input type='text' value=VlrLanc'/></br><label>Hist<label/><input type='text' value=Hist'/></br><label>DtAgendt<label/><input type='text' value=DtAgendt'/></br><label>HrAgendt<label/><input type='text' value=HrAgendt'/></br><label>NivelPref<label/><input type='text' value=NivelPref'/></br><label>DtMovto<label/><input type='text' value=DtMovto'/></br></fieldset></fieldset><fieldset> <legend>USERMSG</legend> </br><label>USERMSG1<label/><input type='text' value=USERMSG1'/></br></fieldset></form>";

            MensagemProvider provider = new MensagemProvider();

            var grupos = provider.retornaSomenteGrupos();

            string output = JsonConvert.SerializeObject(grupos);

            ViewBag.grupos = output;
            return View(grupos);
        }
    }
}
