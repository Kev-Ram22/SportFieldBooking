using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Campos
{
    public class EditModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public EditModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Campo Campo { get; set; }

        // M�todo para cargar los datos del campo a editar
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Campos == null)
            {
                return NotFound();
            }
            var campo = await _context.Campos.FirstOrDefaultAsync(m => m.IdCampo == id);

            if (campo == null)
            {
                return NotFound();
            }
            Campo = campo;
            return Page();
        }


        // M�todo para guardar los cambios en el campo
        public async Task<IActionResult> OnPostAsync(int id)
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            // Recupera la entidad Campo desde la base de datos usando su Id
            var campoToUpdate = await _context.Campos.FindAsync(id);

            // Verifica si el campo con el id proporcionado existe
            if (campoToUpdate == null)
            {
                return NotFound();
            }

            // Aseg�rate de no modificar el IdCampo, ya que es clave primaria
            if (campoToUpdate.IdCampo != id)
            {
                return BadRequest("El Id proporcionado no coincide con el de la entidad.");
            }

            // Asigna los valores a las propiedades modificables del campo
            campoToUpdate.Nombre = Campo.Nombre;  // Aseg�rate de que `Campo` es la entidad del formulario
            campoToUpdate.Ubicaci�n = Campo.Ubicaci�n;
            campoToUpdate.Tipo = Campo.Tipo;

            // Confirma los cambios en la base de datos
            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                // Si hay un problema de concurrencia, puedes manejarlo aqu� (opcional)
                return NotFound();
            }

            // Redirige a la p�gina de �ndice u otra p�gina despu�s de la actualizaci�n
            return RedirectToPage("./Index");
        }

        // M�todo para verificar si el campo existe
        private bool CampoExists(int id)
        {
            return (_context.Campos?.Any(e => e.IdCampo == id)).GetValueOrDefault();
        }
    }
}
