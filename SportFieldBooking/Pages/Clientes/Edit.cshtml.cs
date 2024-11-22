using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Clientes
{
    public class EditModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public EditModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Cliente Cliente { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Clientes == null)
            {
                return NotFound();
            }
            var cliente = await _context.Clientes.FirstOrDefaultAsync(m => m.IdCliente == id);

            if (cliente == null)
            {
                return NotFound();
            }
            Cliente = cliente;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int id)
        {
            var clienteToUpdate = await _context.Clientes.FindAsync(id);

            // Verifica si el campo con el id proporcionado existe
            if (clienteToUpdate == null)
            {
                return NotFound();
            }

            // Asegúrate de no modificar el IdCampo, ya que es clave primaria
            if (clienteToUpdate.IdCliente != id)
            {
                return BadRequest("El Id proporcionado no coincide con el de la entidad.");
            }

            // Asigna los valores a las propiedades modificables del campo
            clienteToUpdate.Nombre = Cliente.Nombre;
            clienteToUpdate.Apellido = Cliente.Apellido;
            clienteToUpdate.Teléfono = Cliente.Teléfono;
            clienteToUpdate.Email = Cliente.Email;

            // Confirma los cambios en la base de datos
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Si hay un problema de concurrencia, puedes manejarlo aquí (opcional)
                return NotFound();
            }

            // Redirige a la página de índice u otra página después de la actualización
            return RedirectToPage("./Index");
        }

        private bool ClienteExists(int id)
        {
            return (_context.Clientes?.Any(e => e.IdCliente == id)).GetValueOrDefault();
        }
    }
}
