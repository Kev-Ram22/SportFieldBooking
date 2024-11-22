using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Eventos
{
    public class DeleteModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public DeleteModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evento Evento { get; set; }

        // M�todo GET para cargar el evento a eliminar
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Evento = await _context.Eventos
                .Include(e => e.Campo) // Incluye informaci�n del campo relacionado
                .FirstOrDefaultAsync(m => m.IdEvento == id);

            if (Evento == null)
            {
                return NotFound();
            }

            return Page();
        }

        // M�todo POST para confirmar la eliminaci�n
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Evento = await _context.Eventos.FindAsync(id);

            if (Evento != null)
            {
                _context.Eventos.Remove(Evento);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
