namespace Negocio
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Evento
    {
        public int InsereEvento()
        {
            Dados.Evento evento = new Dados.Evento();
            return evento.InsereEvento();
        }
    }
}
