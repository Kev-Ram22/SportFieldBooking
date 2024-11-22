using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Reservas
{
    public class EditModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public EditModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            // Verifica si el ID es nulo o si la lista de reservas es nula
            if (id == null || _context.Reservas == null)
            {
                return NotFound();
            }

            // Busca la reserva en la base de datos por el ID
            var reserva = await _context.Reservas
                .Include(r => r.Campo) // Incluir el campo relacionado
                .Include(r => r.Cliente) // Incluir el cliente relacionado
                .FirstOrDefaultAsync(m => m.IdReserva == id);

            // Verifica si la reserva existe
            if (reserva == null)
            {
                return NotFound();
            }

            // Asigna el cliente encontrado a la propiedad Reserva
            Reserva = reserva;

            ViewData["Campos"] = await _context.Campos.ToListAsync();
            ViewData["Clientes"] = await _context.Clientes.ToListAsync();

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            // Obtiene la reserva a editar usando el ID
            var reservaToUpdate = await _context.Reservas.FindAsync(id);

            // Verifica si la reserva existe
            if (reservaToUpdate == null)
            {
                return NotFound();
            }

            // Verifica que el ID proporcionado coincida con el de la entidad
            if (reservaToUpdate.IdReserva != id)
            {
                return BadRequest("El ID proporcionado no coincide con el de la entidad.");
            }

            // Asigna los valores de la reserva a editar
            reservaToUpdate.FechaHoraInicio = Reserva.FechaHoraInicio;
            reservaToUpdate.FechaHoraFin = Reserva.FechaHoraFin;
            reservaToUpdate.Estado = Reserva.Estado;

            // Se puede actualizar también el cliente o el campo si es necesario
            // Si no es necesario, esta parte puede omitirse
            if (Reserva.IdCliente != reservaToUpdate.IdCliente)
            {
                reservaToUpdate.IdCliente = Reserva.IdCliente;
            }

            if (Reserva.IdCampo != reservaToUpdate.IdCampo)
            {
                reservaToUpdate.IdCampo = Reserva.IdCampo;
            }

            // Intenta guardar los cambios en la base de datos
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Manejo de excepciones por concurrencia
                return NotFound();
            }

            // Redirige a la página de índice u otra página después de la actualización
            return RedirectToPage("./Index");
        }

        private bool ReservaExists(int id)
        {
            return (_context.Reservas?.Any(e => e.IdReserva == id)).GetValueOrDefault();
        }
    }
}
