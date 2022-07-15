using NewApp.Model;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System;

namespace NewApp.Servicios
{
    public class DepartamentoService: IDepartamentoService
    {
        private List<Departamento> Departamentos;
       private readonly HospitalDbContext _context;

       public DepartamentoService(HospitalDbContext context){
            _context = context;           
       }

       public List<Departamento> MostrarTodos(){

           return _context.Departamentos.ToList();
           
       }

       public void AgregarDep(Departamento dep)
       {
           _context.Departamentos.Add(dep);
           _context.SaveChanges();
       }

       public void ModificarDep(Departamento dep)
       {
           var depanterior = _context.Departamentos.Find(dep.Id);
           _context.Attach(dep).State = EntityState.Modified;
           _context.SaveChanges();
       }
    }
}