namespace SistemaGestaoConferencia.Eventos.Xml
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using MySql.Data;
    using MySql.Data.MySqlClient;
    using System.Data;
    
    public partial class Endereco : System.Web.UI.Page
    {
        Conexao.Conexao conexao = new Conexao.Conexao();

        protected void Page_Load(object sender, EventArgs e)
        {
            string cep = Request["cep"];
            cep = cep.Replace("-", "");
            this.CarregaEndereco(cep);
        }

        protected void CarregaEndereco(string cep)
        {            
            DataTable tb = new DataTable("endereco");

            tb.Columns.Add("Tipo");
            tb.Columns.Add("Logradouro");
            tb.Columns.Add("Cep");
            tb.Columns.Add("Bairro");
            tb.Columns.Add("Cidade");
            tb.Columns.Add("Estado");
            tb.Columns.Add("id");
            tb.Columns.Add("Bairro_ID");
            tb.Columns.Add("CIdade_ID");
            tb.Columns.Add("Estado_ID");
            tb.Columns.Add("Logradouro_ID");
            tb.Columns.Add("Capital");

            Modelo.Cep Endereco = new Modelo.Cep();
            Endereco.CepEndereco = cep;

            Utilidade.FormataTexto fm = new Utilidade.FormataTexto();

            Modelo.Cep modelo = new Modelo.Cep();
            modelo = this.ObterEndereco(Endereco);
            
            if (modelo != null)
            {
                DataRow linha = tb.NewRow();

                linha["Tipo"] = modelo.Descricao;
                linha["Logradouro"] = fm.Minusculo(modelo.Logradouro);
                linha["Cep"] = modelo.CepEndereco;
                linha["Bairro"] = modelo.NomeBairro;
                linha["Cidade"] = modelo.NomeCidade;
                linha["Estado"] = modelo.NomeEstado;
                linha["id"] = modelo.Endereco_Id;
                linha["Bairro_ID"] = modelo.Bairro_Id;
                linha["CIdade_ID"] = modelo.Cidade_Id;
                linha["Estado_ID"] = modelo.Estado_Id;
                linha["Logradouro_ID"] = modelo.Logradouro_Id;
                linha["Capital"] = modelo.Capital;
                tb.Rows.Add(linha);
            }
        
            Utilidade.Xml DocXml = new Utilidade.Xml();
            Response.Clear();
            Response.ClearContent();
            Response.ClearHeaders();
            Response.ContentType = "text/xml";
            Response.Write(DocXml.GerarXML(tb).OuterXml);
            Response.End();
        }

        protected Modelo.Cep ObterEndereco(Modelo.Cep endereco)
        {
            try
            {
                using(MySqlConnection con = new MySqlConnection(conexao.Con))
                {
                    MySqlCommand comando = new MySqlCommand();
                    comando.CommandText = "SELECT Endereco.Bairro_Id, Endereco.CEP, Endereco.Logradouro, Cidade.Capital, "
                        + "Endereco.Endereco_Id, Endereco.Logradouro_Id, Bairro.NomeBairro, Cidade.NomeCidade, Estado.NomeEstado, "
                        + "Cidade.Cidade_Id, Estado.Estado_Id "
                        + "FROM Endereco "
                        + "JOIN Bairro "
                        + "ON Endereco.Bairro_Id = Bairro.Bairro_Id "
                        + "JOIN Cidade "
                        + "ON Bairro.Cidade_Id = Cidade.Cidade_Id "
                        + "JOIN Estado "
                        + "ON Cidade.Estado_Id = Estado.Estado_Id "
                        + "WHERE Endereco.Cep = @cep ";
                    
                    comando.Parameters.AddWithValue("@cep", endereco.CepEndereco);
                    comando.CommandType = CommandType.Text;
                    comando.Connection = con;
                    con.Open();
                    comando.ExecuteNonQuery();
                                        
                    DataTable dt = new DataTable();
                    MySqlDataAdapter da = new MySqlDataAdapter(comando);
                    da.Fill(dt);

                    if (dt.Rows.Count > 0)
                    {
                        for (int i = 0; i < dt.Rows.Count; i++)
                        {
                            endereco.Bairro_Id = Convert.ToInt32(dt.Rows[i].ItemArray[0].ToString());                    
                            endereco.Logradouro = dt.Rows[i].ItemArray[2].ToString();
                            endereco.Capital = Convert.ToBoolean(dt.Rows[i].ItemArray[3]);
                            endereco.Endereco_Id = Convert.ToInt32(dt.Rows[i].ItemArray[4].ToString());
                            endereco.Logradouro_Id = Convert.ToInt32(dt.Rows[i].ItemArray[5].ToString());
                            endereco.NomeBairro = dt.Rows[i].ItemArray[6].ToString();
                            endereco.NomeCidade = dt.Rows[i].ItemArray[7].ToString();
                            endereco.NomeEstado = dt.Rows[i].ItemArray[8].ToString();
                            endereco.Cidade_Id = Convert.ToInt32(dt.Rows[i].ItemArray[9].ToString());
                            endereco.Estado_Id = Convert.ToInt32(dt.Rows[i].ItemArray[10].ToString());                            
                        }

                        return endereco;
                    }
                    else
                    {
                        return endereco;
                    }
                }
            }
            catch(MySqlException e)
            {
                return endereco;
            }
        }
    }
}