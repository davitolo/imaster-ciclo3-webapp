using System;
using System.Collections.Generic;

namespace Huellitasco.App.Dominio
{
    public class Historia
    {
        public int Id{get; set;}
        public DateTime FechaInicial{get; set;}
        public List<VisitasPyP> VisitasPyP{get; set;}
    }
}
