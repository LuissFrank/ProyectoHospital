using System;
using System.Collections.Generic;

namespace NewApp.Model
{
    public class EstadoPersona
    {
        public int Id {get;set;}
        public string Estado {get;set;}
        public virtual List<Paciente> Pacientes {get;set;}
    }
}