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
    public class DetailsModel : PageModel
    {
        private readonly NewApp.Model.HospitalDbContext _context;

        public DetailsModel(NewApp.Model.HospitalDbContext context)
        {
            _context = context;
        }

        public Paciente Paciente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Paciente = await _context.Pacientes
                .Include(p => p.Estado)
                .Include(p => p.Medico)
                .Include(p => p.ObraSocial)
                .Include(p => p.Sexo)
                .FirstOrDefaultAsync(m => m.ID == id);

            if (Paciente == null)
            {
                return NotFound();
            }
            return Page();
        }
    }
}
