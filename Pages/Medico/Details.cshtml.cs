using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewApp.Model;

namespace NewApp._Pages_Medico
{
    public class DetailsModel : PageModel
    {
        private readonly NewApp.Model.HospitalDbContext _context;

        public DetailsModel(NewApp.Model.HospitalDbContext context)
        {
            _context = context;
        }

        public Medico Medico { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            Medico = await _context.Medicos
                    .Include(m=> m.Departamento)
                    .FirstOrDefaultAsync(m=>m.Id == id);

            Medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Id == id);

            if (Medico == null)
            {
                return NotFound();
            }
                    var Pacasing = _context.Medicos
                                .Include(x=>x.Pacientes)
                                .Where(x=>x.Id == id)
                                .FirstOrDefault();
            ViewData["pacAsing"] = Pacasing.Pacientes; //datos de los pacientes
                    
                    
            return Page();
        }
    }
}
