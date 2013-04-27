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

    public partial class Logradouro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.carregaXml();
        }

        protected void carregaXml()
        {
            try
            {
                DataTable tb = new DataTable("Cidade");

                tb.Columns.Add("Logradouro_Id");
                tb.Columns.Add("Descricao");

                //// Gerando o Select
                string select = "SELECT * FROM Logradouro";

                //// Conectando ao Banco de Dados
                Conexao.Conexao c = new Conexao.Conexao();
                MySqlConnection con = new MySqlConnection(c.Con);
                MySqlCommand cmd = new MySqlCommand(select, con);
                con.Open();
                MySqlDataReader r = cmd.ExecuteReader();

                while (r.Read())
                {
                    DataRow linha = tb.NewRow();
                    linha["Logradouro_Id"] = (int)r["Logradouro_Id"];
                    linha["Descricao"] = r["Descricao"].ToString();
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