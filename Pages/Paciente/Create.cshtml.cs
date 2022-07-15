using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewApp.Model;

namespace NewApp._Pages_Paciente
{
    public class CreateModel : PageModel
    {
        private readonly NewApp.Model.HospitalDbContext _context;

        public CreateModel(NewApp.Model.HospitalDbContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
        ViewData["EstadoId"] = new SelectList(_context.EstadoPersonas, "Id", "Estado");
        ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Apellido");
        ViewData["ObraSocialId"] = new SelectList(_context.Coberturas, "Id", "ObraSocial");
        ViewData["SexoId"] = new SelectList(_context.SexoPersonas, "Id", "Genero");
            return Page();
        }

        [BindProperty]
        public Paciente Paciente { get; set; }

        // To protect from overposting attacks, see https://aka.ms/RazorPagesCRUD
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Pacientes.Add(Paciente);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
