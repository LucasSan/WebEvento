namespace SistemaGestaoConferencia.Eventos.Gerenciar
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Web;
    using System.Web.UI;
    using System.Web.UI.WebControls;
    using MySql.Data;
    using MySql.Data.MySqlClient;

    public partial class NovoEvento : System.Web.UI.Page
    {
        #region :::: Variáveis Públicas ::::

        public string Cep = string.Empty;
        public string Complemento = string.Empty;
        public string Numero = string.Empty;

        #endregion

        protected void Page_Load(object sender, EventArgs e)
        {
        }
    }
}