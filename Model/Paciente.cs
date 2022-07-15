using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace NewApp.Model
{
    public class Paciente
    {
        [Required(ErrorMessage ="ID ES OBLIGATORIO")]
        public int ID {get;set;}
        public string Nombre {get;set;}
        [Required(ErrorMessage ="APELLIDO ES OBLIGATORIO")]
        public string Apellido {get;set;}
        [Required(ErrorMessage ="DNI ES OBLIGATORIO"),Range(1111111,99999999, ErrorMessage="Minimo de 7 numeros")]
        public int DNI {get;set;} 
        public int Edad {get;set;}
        public int SexoId {get;set;}
        public virtual SexoPersona Sexo {get;set;}
        [Required(ErrorMessage ="MOTIVO ES OBLIGATORIA")]
        public string Motivo {get;set;}
        public int ObraSocialId {get;set;}
        public virtual Cobertura ObraSocial {get;set;}
        [Required(ErrorMessage ="ESTADO ES OBLIGATORIO")]
        public int EstadoId {get;set;}
        public virtual EstadoPersona Estado {get;set;}
        public string Descripcion {get;set;}
        public int MedicoId {get;set;}
        public virtual Medico Medico {get;set;}
        
        [NotMapped]
        public string NCompleto 
        {get{return this.Apellido + " " + this.Nombre;}}
    }
}