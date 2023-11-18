using CiudadanosSanos.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using CiudadanosSanos.Models;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Pacientes
{
    public class IndexModel : PageModel
    {
        private readonly CiudadanosSanosContext _context;
       
        public IndexModel(CiudadanosSanosContext context)
        {
            _context = context;
        }
        public IList<Paciente> Pacientes { get; set; } = default!;

        public async Task OnGetAsync()
        {
            if (_context.Paciente != null)
            {
                Pacientes = await _context.Paciente.ToListAsync();
            }
        }

    }
}
