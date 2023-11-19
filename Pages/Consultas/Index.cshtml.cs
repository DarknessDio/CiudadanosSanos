using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Consultas
{
    public class IndexModel : PageModel
    {
        private readonly CiudadanosSanosContext _context;
        public IndexModel(CiudadanosSanosContext context)
        {
            _context = context;
        }
        public IList<Consulta> consultas { get; set; }

        public async Task OnGetAsync()
        {
            if (_context.Consulta != null)
            {
                consultas = await _context.Consulta.Include(p => p.Paciente).ToListAsync();
            }
        }

    }
}
