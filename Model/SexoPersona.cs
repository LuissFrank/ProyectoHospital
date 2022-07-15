using System.Collections.Generic;
using System;

namespace NewApp.Model
{
    public class SexoPersona
    {
        public int Id {get;set;}
        public string Genero {get;set;}
        public virtual List<Paciente> Pacientes {get;set;}
    }
}