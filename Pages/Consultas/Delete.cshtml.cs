using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;

namespace CiudadanosSanos.Pages.Consultas
{
    public class DeleteModel : PageModel
    {
        private readonly CiudadanosSanosContext _context;
        public DeleteModel(CiudadanosSanosContext context)
        {
            _context = context;
        }
        [BindProperty]
        public Consulta Consulta { get; set; } = default!;

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consulta.FirstOrDefaultAsync(c => c.Id == id);
            if (consulta == null)
            {
                return NotFound();
            }
            else
            {
               Consulta  = consulta;
            }
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null || _context.Consulta == null)
            {
                return NotFound();
            }
            var consulta = await _context.Consulta.FindAsync(id);
            if (consulta != null)
            {
                Consulta = consulta;
                _context.Consulta.Remove(consulta);
                await _context.SaveChangesAsync();
            }
            return RedirectToPage("./Index");
        }
    }
}
