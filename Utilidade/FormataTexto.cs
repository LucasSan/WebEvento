namespace Utilidade
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class FormataTexto
    {
        public string Minusculo(string valor)
        {
            if (valor != "" && valor != null)
            {
                valor = valor.ToLower();
                char primeira = char.ToUpper(valor[0]);
                valor = primeira + valor.Substring(1);
                return valor;
            }
            else
            {
                return "";
            }
        }
    }
}