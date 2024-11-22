using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Pagos
{
    public class EditModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public EditModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pago Pago { get; set; }

        // Este es el listado de reservas que se pasará a la vista
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Pagos == null)
            {
                return NotFound();
            }

            var pago = await _context.Pagos
                .Include(p => p.Reserva)
                .ThenInclude(r => r.Campo) // Si Reserva tiene relación con Campo
                .FirstOrDefaultAsync(m => m.IdPago == id);

            if (pago == null)
            {
                return NotFound();
            }

            Pago = pago;

            // Cargar las reservas disponibles para el dropdown
            ViewData["Reservas"] = await _context.Reservas
                .Include(r => r.Campo) // Asegúrate de incluir Campo si lo usas en el dropdown
                .ToListAsync();

            return Page();
        }

        // Este es el método de post para guardar los cambios
        public async Task<IActionResult> OnPostAsync(int id)
        {
            var pagoToUpdate = await _context.Pagos.FindAsync(id);

            if (pagoToUpdate == null)
            {
                return NotFound();
            }

            if (pagoToUpdate.IdPago != id)
            {
                return BadRequest("El Id proporcionado no coincide con el de la entidad.");
            }

            // Asignar los valores del modelo de la vista
            pagoToUpdate.IdReserva = Pago.IdReserva;
            pagoToUpdate.Monto = Pago.Monto;
            pagoToUpdate.FechaPago = Pago.FechaPago;
            pagoToUpdate.MétodoPago = Pago.MétodoPago;

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!PagoExists(Pago.IdPago))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToPage("./Index");
        }

        private bool PagoExists(int id)
        {
            return _context.Pagos.Any(e => e.IdPago == id);
        }
    }
}
