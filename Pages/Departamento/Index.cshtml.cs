using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NewApp.Model;

namespace NewApp._Pages_Departamento
{
    public class IndexModel : PageModel
    {
        private readonly NewApp.Model.HospitalDbContext _context;

        public IndexModel(NewApp.Model.HospitalDbContext context)
        {
            _context = context;
        }

        public IList<Departamento> Departamento { get;set; }

        public async Task OnGetAsync()
        {
            Departamento = await _context.Departamentos.ToListAsync();
        }

      
    }
}
