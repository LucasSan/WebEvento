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

    public partial class Cidade : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                int Estado = Convert.ToInt32(Request.QueryString["estado"]);
                int Cidade_Id = 0;

                if (Request.QueryString["cidade"] != "")
                {
                    Cidade_Id = Convert.ToInt32(Request.QueryString["cidade"]);
                }

                this.carregaXml(Estado, Cidade_Id);
            }
            catch
            {
            }
        }

        protected void carregaXml(int Estado_Id, int Cidade_Id)
        {
            try
            {
                DataTable tb = new DataTable("Cidade");

                tb.Columns.Add("Cidade_Id");
                tb.Columns.Add("Estado_Id");
                tb.Columns.Add("NomeCidade");                
                tb.Columns.Add("CepCidade");
                tb.Columns.Add("Capital");

                //// Gerando o Select
                string select = "SELECT * FROM Cidade WHERE Estado_Id = " + Estado_Id;
                
                //// Conectando ao Banco de Dados
                Conexao.Conexao c = new Conexao.Conexao();
                MySqlConnection con = new MySqlConnection(c.Con);
                MySqlCommand cmd = new MySqlCommand(select, con);
                con.Open();
                MySqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    DataRow linha = tb.NewRow();
                    linha["Cidade_Id"] = (int)r["Cidade_Id"];
                    linha["Estado_Id"] = r["Estado_Id"].ToString();
                    linha["NomeCidade"] = r["NomeCidade"].ToString();                
                    linha["CepCidade"] = r["CepCidade"].ToString();
                    linha["Capital"] = r["Capital"].ToString();
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