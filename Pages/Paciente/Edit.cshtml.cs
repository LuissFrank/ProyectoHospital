using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using NewApp.Model;

namespace NewApp._Pages_Paciente
{
    public class EditModel : PageModel
    {
        private readonly NewApp.Model.HospitalDbContext _context;

        public EditModel(NewApp.Model.HospitalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
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
                .Include(p => p.Sexo).FirstOrDefaultAsync(m => m.ID == id);

            if (Paciente == null)
            {
                return NotFound();
            }
           ViewData["EstadoId"] = new SelectList(_context.EstadoPersonas, "Id", "Estado");
           ViewData["MedicoId"] = new SelectList(_context.Medicos, "Id", "Apellido");
           ViewData["ObraSocialId"] = new SelectList(_context.Coberturas, "Id", "ObraSocial");
           ViewData["SexoId"] = new SelectList(_context.SexoPersonas, "Id", "Genero");
            return Page();
        }

        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see https://aka.ms/RazorPagesCRUD.
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Attach(Paciente).State = EntityState.Modified;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PacienteExists(Paciente.ID))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PacienteExists(int id)
        {
            return _context.Pacientes.Any(e => e.ID == id);
        }
    }
}
