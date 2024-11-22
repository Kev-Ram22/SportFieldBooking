using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Pagos
{
    public class CreateModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public CreateModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Pago Pago { get; set; }

        // Para mostrar las Reservas en un dropdown
        public SelectList ReservasSelectList { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Cargar las Reservas disponibles
            var reservas = await _context.Reservas.ToListAsync();
            ReservasSelectList = new SelectList(reservas, "IdReserva", "IdReserva");

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    // Si hay errores de validación, recargar el formulario
            //    var reservas = await _context.Reservas.ToListAsync();
            //    ReservasSelectList = new SelectList(reservas, "IdReserva", "IdReserva");
            //    return Page();
            //}

            // Agregar el Pago a la base de datos
            _context.Pagos.Add(Pago);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index"); // Redirigir al listado de pagos
        }
    }
}
