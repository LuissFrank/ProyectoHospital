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
    public class DeleteModel : PageModel
    {
        private readonly NewApp.Model.HospitalDbContext _context;

        public DeleteModel(NewApp.Model.HospitalDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Medico Medico { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medico = await _context.Medicos.FirstOrDefaultAsync(m => m.Id == id);

            if (Medico == null)
            {
                return NotFound();
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Medico = await _context.Medicos.FindAsync(id);

            if (Medico != null)
            {
                _context.Medicos.Remove(Medico);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
