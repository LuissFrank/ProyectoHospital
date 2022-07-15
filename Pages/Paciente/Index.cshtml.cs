using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewApp.Model;

namespace NewApp._Pages_Paciente
{
    public class IndexModel : PageModel
    {
        private readonly NewApp.Model.HospitalDbContext _context;
        
        
        public IndexModel(NewApp.Model.HospitalDbContext context)
        {
            _context = context;
        }

        public IList<Paciente> Paciente { get;set; }

        public async Task OnGetAsync(string orden)
        {
            Paciente = await _context.Pacientes
                .Include(p => p.Estado)
                .Include(p => p.Medico)
                .Include(p => p.ObraSocial)
                .Include(p => p.Sexo)
                .ToListAsync();
            
            if(orden == "Apellido")
            {
                Paciente = await _context.Pacientes
                            .Include(p => p.Estado)
                            .Include(p => p.Medico)
                            .Include(p => p.ObraSocial)
                            .Include(p => p.Sexo)
                            .OrderBy(x=> x.Apellido)
                            .ToListAsync();
            }


            
        }

        public async Task OnPostBuscar(string apellido)
        {
            Paciente = await _context.Pacientes
                        .Where(x=> x.Apellido == apellido)
                        .ToListAsync();
        }


    
    }
}
