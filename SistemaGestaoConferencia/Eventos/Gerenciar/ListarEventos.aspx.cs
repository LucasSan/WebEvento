namespace SistemaGestaoConferencia.Eventos.Gerenciar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;    

    public partial class ListarEventos : System.Web.UI.Page
    {
        #region :::: Variáveis Globais ::::

        public string NomeCidade = string.Empty;
        public string NomeBairro = string.Empty;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected string HeaderTabela(string cidade, string bairro)
        {
            string html = string.Empty;
            
            if (cidade != this.NomeCidade)
            {
                html = "<tr>" +
                        "    <td colspan='7' class='tabelaCidade'>" + cidade + "</td>" +
                        "</tr>" +
                        "<tr>" +
                        "    <td colspan='7' class='tabelaBairro'>" + bairro + "</td>" +
                        "</tr>" +
                        "<tr class='tabeladados'>" +
                        "    <td style='border:none; width:20px;'>código</td>" +
                        "    <td style='border:none; width:20px;'>Para</td>" +
                        "    <td style='border:none; width:60px;'>Área m²</td>" +
                        "    <td style='border:none;'>Endereco</td>" +
                        "    <td style='border:none; width:40px;'>Tipo</td>" +
                        "    <td style='border:none; width:100px;'>Valor</td>" +
                        "    <td style='border:none; width:40px;'>foto</td>" +
                        "</tr>";

                this.NomeCidade = cidade;
                this.NomeBairro = bairro;
            }
            else
            {
                if (bairro != this.NomeBairro)
                {
                    html = "<tr>" +
                    "    <td colspan='7' class='tabelaBairro'>" + bairro + "</td>" +
                    "</tr>" +
                    "<tr class='tabeladados'>" +
                    "    <td style='border:none; width:20px;'>código</td>" +
                    "    <td style='border:none; width:20px;'>Para</td>" +
                    "    <td style='border:none; width:60px;'>Área m²</td>" +
                    "    <td style='border:none;'>Endereco</td>" +
                    "    <td style='border:none; width:40px;'>Tipo</td>" +
                    "    <td style='border:none; width:100px;'>Valor</td>" +
                    "    <td style='border:none; width:20px;'>foto</td>" +
                    "</tr>";

                    this.NomeBairro = bairro;
                }
            }

            return html;
        }

        protected string FormataEvento(string contrato, string statusImovel, string grupo)
        {
            string valor = "class='tabelaMouseHover' data-original-title='Autorizado' rel='tooltip'";

            if (contrato == "2")            
                valor = "class='tabelaExclusivo tabelaMouseHover' data-original-title='Exclusivo' rel='tooltip'";            
            
            if (statusImovel == "12")            
                valor = "class='tabelaProposta tabelaMouseHover'  data-original-title='Proposta' rel='tooltip'";            
            
            if (grupo == "1" && statusImovel != "12")            
                valor = "class='tabelaCorporativo tabelaMouseHover'  data-original-title='Corporativo' rel='tooltip'";            
            
            return valor;
        }

        protected string Endereco(string des, string end, string num, string com, string credenciada, string status)
        {
            //// string cred = tk.CarregaToken(1, Request.Cookies["token"].Value);

            System.Globalization.CultureInfo cultureinfo = System.Threading.Thread.CurrentThread.CurrentCulture;

            //// Coloca tudo em minusculo
            des = des.ToLower();
            end = end.ToLower();
            com = com.ToLower();

            string retorno = des + " " + end + " n° " + num + " " + com;

            string retornoFormatado = string.Empty;
            string[] quebra = retorno.Split(' ');
            
            foreach (string novastring in quebra)
            {
                retornoFormatado += this.PrimeiraMaiuscula(novastring) + " ";
            }

            retorno = retornoFormatado;

            //if (status == "12")
            //{
            //    if (cred != credenciada)
            //    {
            //        retorno = "<span class='label label-info'>imóvel com proposta</span>";
            //    }
            //}

            return retorno;
        }

        protected string PrimeiraMaiuscula(string str)
        {
            string novo = str;

            if (str.Length > 2)
            {
                novo = char.ToUpper(str[0]) + str.Substring(1);
            }

            return novo;
        }
    }
}