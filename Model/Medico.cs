using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Http;
using System.Collections.Generic;


namespace NewApp.Model
{
    public class Medico
    {
        public int Id {get;set;}
        public string Nombre {get;set;}
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public string Apellido {get;set;}
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public int DNI {get;set;}
        [Required(ErrorMessage ="Este campo es obligatorio")]
        public int Matricula {get;set;}
        public int DepartamentoId {get;set;}
        public virtual Departamento Departamento {get;set;}
        public virtual List<Paciente> Pacientes {get;set;}
        public string Fotoruta {get;set;}
        [NotMapped]
        public IFormFile Foto {get;set;}

        [NotMapped]
        public string NCompleto 
        {get{return this.Apellido + " " + this.Nombre;}}

    }
}