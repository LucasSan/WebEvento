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

    public partial class Estado : System.Web.UI.Page
    {
        Conexao.Conexao conexao = new Conexao.Conexao();

        protected void Page_Load(object sender, EventArgs e)
        {
            this.carregaXml();
        }

        protected void carregaXml()
        {
            try
            {
                DataTable tb = new DataTable("Estados");

                tb.Columns.Add("Estado_Id");
                tb.Columns.Add("SiglaEstado");
                tb.Columns.Add("NomeEstado");                

                //// Gerando o Select
                string select = "SELECT * FROM Estado ";
                
                //// Conectando ao Banco de Dados                
                MySqlConnection con = new MySqlConnection(conexao.Con);
                MySqlCommand cmd = new MySqlCommand(select, con);
                con.Open();
                MySqlDataReader r = cmd.ExecuteReader();
                
                while (r.Read())
                {
                    DataRow linha = tb.NewRow();
                    linha["Estado_Id"] = (int)r["Estado_Id"];
                    linha["SiglaEstado"] = r["SiglaEstado"].ToString();
                    linha["NomeEstado"] = r["NomeEstado"].ToString();                    
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