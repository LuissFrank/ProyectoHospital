using System;
using System.Collections.Generic;
namespace NewApp.Model
{
    public class Departamento
    {
        public int Id {get;set;}
        public string Especialidad {get;set;}
        public virtual List <Medico> Medicos {get;set;}
    }
}