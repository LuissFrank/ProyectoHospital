using System;
using System.Collections.Generic;

namespace NewApp.Model
{
    public class Cobertura
    {
        public int Id {get;set;}
        public string ObraSocial {get;set;}
        public int NroSocio {get;set;}
        public virtual List<Paciente> Pacientes {get;set;}
    }
}