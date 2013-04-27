namespace Modelo
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Cep
    {
        public string Descricao { get; set; }
        public string Logradouro { get; set; }
        public string CepEndereco { get; set; }
        public string NomeBairro { get; set; }
        public string NomeCidade { get; set; }
        public string NomeEstado { get; set; }
        public int Logradouro_Id { get; set; }
        public int Endereco_Id { get; set; }
        public int Bairro_Id { get; set; }
        public int Cidade_Id { get; set; }
        public int Estado_Id { get; set; }
        public Boolean Capital { get; set; }
    }
}
