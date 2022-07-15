using NewApp.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;



namespace NewApp.Servicios
{
   public class PacienteService : IPaciente
   {
       private List<Paciente> Pacientes;
       private readonly HospitalDbContext _context;

       public PacienteService(HospitalDbContext context){
            _context = context;           
       }

       public List<Paciente> MostrarTodos(){

           return _context.Pacientes.ToList();
           
       }

       public void Agregar(Paciente paciente)
       {
           _context.Pacientes.Add(paciente);
           _context.SaveChanges();
       }

       public void Eliminar(Paciente paciente)
       {
           var pacienteanterior = _context.Pacientes.Find(paciente.ID);
           _context.Pacientes.Remove(pacienteanterior);
           _context.SaveChanges();
       }

       public void Modificar(Paciente paciente)
       {
           var pacienteanterior = _context.Pacientes.Find(paciente.ID);
           _context.Attach(paciente).State = EntityState.Modified;
           _context.SaveChanges();
       }
   }
}