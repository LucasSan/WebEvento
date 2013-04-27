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

    public partial class LogradouroBairro : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            int bairro = Convert.ToInt32(Request.QueryString["bairro"]);
            
            if (Request.QueryString["cep"] != null && Request.QueryString["cep"] != "")
            {
                int Endereco_id = Convert.ToInt32(Request.QueryString["cep"]);
                this.carregaXmlCep(bairro, Endereco_id);
            }
            else
            {
                carregaXml(bairro);
            }
        }

        protected void carregaXmlCep(int Bairro, int Endereco_Id)
        {
            DataTable tb = new DataTable("Logradouro");

            tb.Columns.Add("Descricao");
            tb.Columns.Add("Logradouro");
            tb.Columns.Add("Cep");
            tb.Columns.Add("Bairro");
            tb.Columns.Add("Cidade");
            tb.Columns.Add("Estado");
            tb.Columns.Add("Endereco_Id");
            tb.Columns.Add("Bairro_ID");
            tb.Columns.Add("CIdade_ID");
            tb.Columns.Add("Estado_ID");
            tb.Columns.Add("Logradouro_ID");
            //tb.Columns.Add("Capital");

            //// Gerando o Select
            string select = "SELECT * " 
                + "FROM Endereco " 
                + "JOIN Bairro "
                + "ON Endereco.Bairro_Id = Bairro.Bairro_Id "
                + "JOIN Cidade "
                + "ON Bairro.Cidade_Id = Cidade.Cidade_Id "
                + "JOIN Estado "
                + "ON Cidade.Estado_Id = Estado.Estado_Id "
                + "JOIN Logradouro "
                + "ON Endereco.Logradouro_Id = Logradouro.Logradouro_Id "
                + "WHERE Endereco.Bairro_Id = " + Bairro + " " 
                + "OR Endereco.Endereco_id = " + Endereco_Id + " " 
                + "ORDER BY Endereco.Logradouro ASC";

            //// Conectando ao Banco de Dados
            Conexao.Conexao c = new Conexao.Conexao();
            MySqlConnection con = new MySqlConnection(c.Con);
            MySqlCommand cmd = new MySqlCommand(select, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            Utilidade.FormataTexto fm = new Utilidade.FormataTexto();

            while (r.Read())
            {
                DataRow linha = tb.NewRow();
                linha["Descricao"] = r["Descricao"].ToString();
                linha["Logradouro"] = fm.Minusculo(r["Logradouro"].ToString());
                linha["Cep"] = r["Cep"].ToString();
                linha["Bairro"] = r["NomeBairro"].ToString();
                linha["Cidade"] = r["NomeCidade"].ToString();
                linha["Estado"] = r["NomeEstado"].ToString();
                linha["Endereco_Id"] = (int)r["Endereco_Id"];
                linha["Bairro_Id"] = (int)r["Bairro_Id"];
                linha["CIdade_Id"] = (int)r["CIdade_Id"];
                linha["Estado_Id"] = (int)r["Estado_Id"];
                linha["Logradouro_Id"] = (int)r["Logradouro_Id"];
                //linha["Capital"] = Convert.ToBoolean(r["Capital"].ToString());
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

        protected void carregaXml(int Bairro)
        {
            DataTable tb = new DataTable("Logradouro");

            tb.Columns.Add("Descricao");
            tb.Columns.Add("Logradouro");
            tb.Columns.Add("Cep");
            tb.Columns.Add("Bairro");
            tb.Columns.Add("Cidade");
            tb.Columns.Add("Estado");
            tb.Columns.Add("Endereco_Id");
            tb.Columns.Add("Bairro_ID");
            tb.Columns.Add("CIdade_ID");
            tb.Columns.Add("Estado_ID");
            tb.Columns.Add("Logradouro_ID");
            tb.Columns.Add("Capital");

            //// Gerando o Select
            string select = "SELECT * " 
                + "FROM View_Endereco " 
                + "WHERE Bairro_Id = " + Bairro + " " 
                + "ORDER BY Logradouro ASC";

            //// Conectando ao Banco de Dados
            Conexao.Conexao c = new Conexao.Conexao();
            MySqlConnection con = new MySqlConnection(c.Con);
            MySqlCommand cmd = new MySqlCommand(select, con);
            con.Open();
            MySqlDataReader r = cmd.ExecuteReader();
            Utilidade.FormataTexto fm = new Utilidade.FormataTexto();
            
            while (r.Read())
            {
                DataRow linha = tb.NewRow();
                linha["Descricao"] = r["Descricao"].ToString();
                linha["Logradouro"] = fm.Minusculo(r["Logradouro"].ToString());
                linha["Cep"] = r["Cep"].ToString();
                linha["Bairro"] = r["NomeBairro"].ToString();
                linha["Cidade"] = r["NomeCidade"].ToString();
                linha["Estado"] = r["NomeEstado"].ToString();
                linha["Endereco_Id"] = (int)r["Endereco_Id"];
                linha["Bairro_Id"] = (int)r["Bairro_Id"];
                linha["CIdade_Id"] = (int)r["CIdade_Id"];
                linha["Estado_Id"] = (int)r["Estado_Id"];
                linha["Logradouro_Id"] = (int)r["Logradouro_Id"];
                linha["Capital"] = Convert.ToBoolean(r["Capital"].ToString());
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
    }
}