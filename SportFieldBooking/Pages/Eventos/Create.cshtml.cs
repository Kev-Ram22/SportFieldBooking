using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Eventos
{
    public class CreateModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public CreateModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evento Evento { get; set; }

        public SelectList CamposList { get; set; } // Para el menú desplegable de campos

        public async Task<IActionResult> OnGetAsync()
        {
            // Cargar la lista de campos para el dropdown
            CamposList = new SelectList(await _context.Campos.ToListAsync(), "IdCampo", "Nombre");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Guardar el evento en la base de datos
            _context.Eventos.Add(Evento);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
