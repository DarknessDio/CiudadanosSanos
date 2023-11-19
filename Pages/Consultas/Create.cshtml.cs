using CiudadanosSanos.Data;
using CiudadanosSanos.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CiudadanosSanos.Pages.Consultas
{
    public class CreateModel : PageModel
    {
        private readonly CiudadanosSanosContext _context;
        public CreateModel(CiudadanosSanosContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            ListPacientes();
            return Page();
        }

        [BindProperty]
        public Consulta consulta { get; set; } = default!;

        public SelectList Pacientes { get; set; }

        private void ListPacientes()
        {
            var pacientes = _context.Paciente.ToList();
            Pacientes = new SelectList(pacientes, "Id", "Name");
        }
        public async Task<ActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid || _context.Consulta == null || consulta == null)
            {
                ListPacientes();
                return Page();
            }
            _context.Consulta.Add(consulta);
            await _context.SaveChangesAsync();
            return RedirectToPage("./Index");
        }
    }
}
