using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewApp.Model;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace NewApp._Pages_Departamento
{
    public class DetailsModel : PageModel
    {
        private readonly NewApp.Model.HospitalDbContext _context;

        public DetailsModel(NewApp.Model.HospitalDbContext context)
        {
            _context = context;
        }

        public Departamento Departamento { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Departamento = await _context.Departamentos.FirstOrDefaultAsync(m => m.Id == id);

            if (Departamento == null)
            {
                return NotFound();
            }
            ViewData["ComboMedico"]= new SelectList(_context.Medicos.ToList(),"Id","NCompleto");
                var Mecasing = _context.Departamentos
                                .Include(x=>x.Medicos)
                                .Where(x=>x.Id == id)
                                .FirstOrDefault();
            ViewData["MedAsig"] = Mecasing.Medicos; //lista de medicos de esa especialidad
            return Page();
        }
    }
}
