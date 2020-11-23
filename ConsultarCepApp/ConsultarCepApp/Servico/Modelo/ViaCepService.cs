using System;
using System.Collections.Generic;
using System.Text;
using System.Net;
using ConsultarCepApp.Servico.Modelo;
using Newtonsoft.Json;

namespace ConsultarCepApp.Servico.Modelo
{
    public class ViaCepService
    {
        private static string EnderecoUrl = "http://viacep.com.br/ws/{0}/json/";

        public static Endereco BuscaEnderecoViacep(string cep) {
            string NovoEnderecoUrl = string.Format(EnderecoUrl, cep);

            WebClient wc = new WebClient();


            string retorno = wc.DownloadString(NovoEnderecoUrl);

            Endereco end = JsonConvert.DeserializeObject<Endereco>(retorno);
            if (end.cep == null)
            {
                return null;
            }
            else {
                return end;
            }
            
        }

        
        

    }
}
