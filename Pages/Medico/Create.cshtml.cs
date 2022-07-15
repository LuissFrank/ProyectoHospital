using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using NewApp.Model;

namespace NewApp._Pages_Medico
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
            ViewData["Departamentos"]= new SelectList(_context.Departamentos.ToList(),"Id","Especialidad");
            return Page();
        }

        [BindProperty]
        public Medico Medico { get; set; }

        
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Medicos.Add(Medico);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
