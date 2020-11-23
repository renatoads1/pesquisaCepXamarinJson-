using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using ConsultarCepApp.Servico.Modelo;
using ConsultarCepApp.Servico;

namespace ConsultarCepApp
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Botao.Clicked += btnOnclic;

        }

        private void btnOnclic(object sender, EventArgs args) {
            string cep = Cep.Text.Trim();
            if (cepValido(cep))
            {
                try
                {
                    if (cep != null)
                    {
                        Endereco end = ViaCepService.BuscaEnderecoViacep(cep);
                        Resultado.Text = "Rua" + end.logradouro;

                    }
                    else {
                        DisplayAlert("ERRO CRITICO","Cep Não existe -> "+Cep.Text, "ok");
                    }

                }
                catch (Exception e)
                {
                    DisplayAlert("ERRO CRITICO", e.ToString() , "ok");
                }
                
            }
            else { 
                
            } 
            
        }

        private bool cepValido(string cep)
        {
            bool valido = true;
            if (cep.Length != 8) {
                valido = false;
                DisplayAlert("ERRO","O Cep deve ter 8 caracteres!!!","ok");
            }
            int cepNovo = 0;
            if (!int.TryParse(cep,out cepNovo)) {
                valido = false;
                DisplayAlert("ERRO", "O Cep deve ter Apenas Números", "ok");
            }

            return valido;
        }


    }
}
