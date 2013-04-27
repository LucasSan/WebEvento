namespace SistemaGestaoConferencia.Eventos.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using MySql.Data;
    using MySql.Data.MySqlClient;

    public partial class Bairro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int Cidade = Convert.ToInt32(Request.QueryString["cidade"]);
                this.carregaXml(Cidade);
            }
            catch
            {
            }
        }

        protected void carregaXml(int Cidade)
        {
            try
            {
                DataTable tb = new DataTable("Cidade");

                tb.Columns.Add("Bairro_Id");
                tb.Columns.Add("Regiao_Id");
                tb.Columns.Add("Cidade_Id");
                tb.Columns.Add("NomeBairro");                

                //// Gerando o Select
                string select = "SELECT * FROM Bairro WHERE Cidade_Id = " + Cidade + " ORDER BY NomeBairro ASC";
                
                //// Conectando ao Banco de Dados
                Conexao.Conexao c = new Conexao.Conexao();
                MySqlConnection con = new MySqlConnection(c.Con);
                MySqlCommand cmd = new MySqlCommand(select, con);
                con.Open();
                MySqlDataReader r = cmd.ExecuteReader();
                
                while (r.Read())
                {
                    DataRow linha = tb.NewRow();
                    linha["Bairro_Id"] = Convert.ToInt32(r["Bairro_Id"].ToString());
                    linha["Regiao_Id"] = r["Regiao_Id"] != null ? r["Regiao_Id"].ToString() : string.Empty;
                    linha["Cidade_Id"] = r["Cidade_Id"].ToString();
                    linha["NomeBairro"] = r["NomeBairro"].ToString();                    
                    tb.Rows.Add(linha);
                }

                con.Close();
                Utilidade.Xml DocXml = new Utilidade.Xml();
                Response.Clear();
                Response.ClearContent();
                Response.ClearHeaders();
                Response.ContentType = "text/xml";
                Response.Write(DocXml.GerarXML(tb).OuterXml);
                Response.End();
            }
            catch
            {
            }
        }
    }
}