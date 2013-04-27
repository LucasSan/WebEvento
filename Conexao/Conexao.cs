namespace Conexao
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Conexao
    {
        private string _conexao = @"Server=localhost;Database=gestaoevento;Uid=root;Pwd=203940391;";

        public string Con
        {
            get { return _conexao; }
            set { _conexao = value; }
        }
    }
    
}
