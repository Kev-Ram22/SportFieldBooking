using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Pagos
{
    public class DeleteModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public DeleteModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pago Pago { get; set; }

        // Método GET para cargar el pago a eliminar
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pago = await _context.Pagos
                .Include(p => p.Reserva) // Incluye información de la reserva asociada
                .FirstOrDefaultAsync(m => m.IdPago == id);

            if (Pago == null)
            {
                return NotFound();
            }

            return Page();
        }

        // Método POST para confirmar la eliminación
        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Pago = await _context.Pagos.FindAsync(id);

            if (Pago != null)
            {
                _context.Pagos.Remove(Pago);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
