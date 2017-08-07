using Microsoft.Xml.XMLGen;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Xml;
using System.Xml.Schema;
using XSDtoHTML.Models;

namespace XSDtoHTML.Providers
{
    public class MensagemProvider
    {

        public List<GrupoMensagem> retornaGrupos()
        {
            List<String> xmls = new List<string>();
            Dictionary<string, List<string>> mapaXsd = new Dictionary<string, List<string>>();
            List<GrupoMensagem> grupo = new List<GrupoMensagem>();
            var directories = Directory.GetDirectories(@"C:\Users\cesar\documents\visual studio 2017\Projects\ConsoleApplication1\ConsoleApplication1\XSDDOCV409\");
            foreach (string dir in directories)
            {
                string nomeDir = dir.Replace(@"C:\Users\cesar\documents\visual studio 2017\Projects\ConsoleApplication1\ConsoleApplication1\XSDDOCV409\", "");
                var sub = Directory.GetFiles(dir);
                Console.Write("");
                GrupoMensagem grupoMensagem = new GrupoMensagem();
                grupoMensagem.nome = nomeDir;
                xmls = new List<string>();
                foreach (string file in sub)
                {
                    if (grupoMensagem.mensagens == null)
                    {
                        grupoMensagem.mensagens = new List<Mensagem>();
                    }
                    grupoMensagem.mensagens.Add(LerXsd(file, file.Replace(dir, "").Replace(@"\", "").Replace(".XSD", "")));
                }
                grupo.Add(grupoMensagem);

            }
            return grupo;

        }

        public List<GrupoMensagem> retornaSomenteGrupos()
        {
            List<String> xmls = new List<string>();
            Dictionary<string, List<string>> mapaXsd = new Dictionary<string, List<string>>();
            List<GrupoMensagem> grupo = new List<GrupoMensagem>();
            var directories = Directory.GetDirectories(@"C:\Users\cesar\documents\visual studio 2017\Projects\ConsoleApplication1\ConsoleApplication1\XSDDOCV409\");
            foreach (string dir in directories)
            {
                string nomeDir = dir.Replace(@"C:\Users\cesar\documents\visual studio 2017\Projects\ConsoleApplication1\ConsoleApplication1\XSDDOCV409\", "");
                var sub = Directory.GetFiles(dir);
                Console.Write("");
                GrupoMensagem grupoMensagem = new GrupoMensagem();
                grupoMensagem.nome = nomeDir;
                xmls = new List<string>();
                foreach (string file in sub)
                {
                    if (grupoMensagem.mensagens == null)
                    {
                        grupoMensagem.mensagens = new List<Mensagem>();
                    }                    
                }
                grupo.Add(grupoMensagem);

            }
            return grupo;
        }

        public List<Mensagem> MensagensDoGrupo(string grupo)
        {
            List<String> xmls = new List<string>();
            Dictionary<string, List<string>> mapaXsd = new Dictionary<string, List<string>>();
            GrupoMensagem grupoMensagem = new GrupoMensagem();
            var directories = Directory.GetDirectories(@"C:\Users\cesar\documents\visual studio 2017\Projects\ConsoleApplication1\ConsoleApplication1\XSDDOCV409\");
            foreach (string dir in directories)
            {
                string nomeDir = dir.Replace(@"C:\Users\cesar\documents\visual studio 2017\Projects\ConsoleApplication1\ConsoleApplication1\XSDDOCV409\", "");
                var sub = Directory.GetFiles(dir);
                Console.Write("");
                grupoMensagem.nome = nomeDir;
                if (grupoMensagem.nome.Equals(grupo))
                {
                    xmls = new List<string>();
                    foreach (string file in sub)
                    {
                        if (grupoMensagem.mensagens == null)
                        {
                            grupoMensagem.mensagens = new List<Mensagem>();
                        }
                        grupoMensagem.mensagens.Add(LerXsd(file, file.Replace(dir, "").Replace(@"\", "").Replace(".XSD", "")));
                    }

                }
                
            }
            return grupoMensagem.mensagens;
        }

        public Mensagem LerXsd(string xsdPath, string nomeMensagem)
        {
            Mensagem mensagem = new Mensagem();
            mensagem.nome = nomeMensagem;
            using (var stream = new MemoryStream(File.ReadAllBytes(xsdPath)))
            {
                var schema = XmlSchema.Read(XmlReader.Create(stream), null);
                var gen = new XmlSampleGenerator(schema, new XmlQualifiedName("rootElement"));

                try
                {
                    var xmlString = new StringWriter();
                    gen.WriteXml(XmlWriter.Create(xmlString));
                    //var texto = xmlString.ToString();
                    if (!xmlString.ToString().Equals(""))
                    {
                        XmlDocument document = new XmlDocument();
                        document.LoadXml(xmlString.ToString());
                        mensagem.xml = xmlString.ToString();
                        XmlElement root = document.DocumentElement;
                        StringBuilder sb = new StringBuilder("<form> <br>");
                        foreach (XmlNode noPrincipal in root.ChildNodes)
                        {
                            sb.Append("<fieldset> <legend>" + noPrincipal.Name + "</legend> </br>");
                            bool noTemFilhos = noPrincipal.HasChildNodes;

                            //Console.WriteLine(noPrincipal.Name);
                            foreach (XmlNode subNo in noPrincipal.ChildNodes)
                            {


                                //input
                                //ou um field novo
                                // Console.WriteLine(subNo.Name);
                                if (subNo.ChildNodes.Count > 1)
                                {
                                    bool subNoFilho = subNo.HasChildNodes;
                                    sb.Append("<fieldset> <legend>" + subNo.Name + "</legend> </br>");
                                    foreach (XmlNode subNo2 in subNo.ChildNodes)
                                    {
                                        sb.Append("<label>" + subNo2.Name + "<label/>");
                                        sb.Append("<input type='text' value=" + subNo2.Name + "'/></br>");
                                        //Console.WriteLine(subNo2.Name);
                                        bool subNoFilho2 = subNo2.HasChildNodes;
                                    }
                                    sb.Append("</fieldset>");
                                }
                                else
                                {
                                    if (subNo.Name.Contains("text"))
                                    {
                                        sb.Append("<label>" + subNo.InnerText + "<label/>");
                                        sb.Append("<input type='text' value=" + subNo.InnerText + "'/></br>");
                                    }
                                    else
                                    {
                                        sb.Append("<label>" + subNo.Name + "<label/>");
                                        sb.Append("<input type='text' value=" + subNo.Name + "'/></br>");
                                    }
                                }
                            }
                            sb.Append("</fieldset>");
                            //fechar o field set
                        }
                        sb.Append("</form>");
                        mensagem.html = sb.ToString();
                        return mensagem;

                    }

                }
                catch (Exception ex)
                {
                    Console.WriteLine("Erro ao ler:" + xsdPath);
                }


            }

            return null;
        }
    }
}