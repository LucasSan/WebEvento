namespace Dados
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;
    using MySql.Data;
    using MySql.Data.MySqlClient;

    public class Evento
    {
        #region :::: Variáveis Públicas ::::

        Conexao.Conexao conexao = new Conexao.Conexao();

        #endregion

        public int InsereEvento()
        {
            try
            {
                using(MySqlConnection con = new MySqlConnection(conexao.Con))
                {
                    string procedure = "proc_InsereEvento";
                    MySqlCommand comando = new MySqlCommand(procedure, con);
                    con.Open();

                    return 1;
                }
            }
            catch
            {
                return 0;
            }
        }
    }
}
