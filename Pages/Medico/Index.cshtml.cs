using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewApp.Model;

namespace NewApp._Pages_Medico
{
    public class IndexModel : PageModel
    {
        private readonly NewApp.Model.HospitalDbContext _context;

        public IndexModel(NewApp.Model.HospitalDbContext context)
        {
            _context = context;
        }

        public IList<Medico> Medico { get;set; }

        public async Task OnGetAsync(string orden)
        {
            Medico = await _context.Medicos.ToListAsync();
            if(orden == "Apellido")
            {
                Medico = await _context.Medicos
                            .OrderBy(x=> x.Apellido)
                            .ToListAsync();
            }
        }

        public async Task OnPostBuscar(string apellido)
        {
            Medico = await _context.Medicos
                        .Where(x=> x.Apellido == apellido)
                        .ToListAsync();
        }
    }
}
