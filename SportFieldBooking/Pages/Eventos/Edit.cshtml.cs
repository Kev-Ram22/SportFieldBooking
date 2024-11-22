using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Eventos
{
    public class EditModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public EditModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Evento Evento { get; set; }

        // Cargar los campos para la vista desplegable
        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null || _context.Eventos == null)
            {
                return NotFound();
            }

            var evento = await _context.Eventos
                .Include(e => e.Campo)  // Cargar el Campo relacionado
                .FirstOrDefaultAsync(m => m.IdEvento == id);

            if (evento == null)
            {
                return NotFound();
            }

            Evento = evento;

            // Cargar los Campos disponibles para la selección
            ViewData["Campos"] = await _context.Campos.ToListAsync();

            return Page();
        }

        // Procesar el formulario para actualizar el Evento
        public async Task<IActionResult> OnPostAsync(int id)
        {

            var eventoToUpdate = await _context.Eventos.FindAsync(id);

            if (eventoToUpdate == null)
            {
                return NotFound();
            }

            // Actualizar los valores del evento
            eventoToUpdate.NombreEvento = Evento.NombreEvento;
            eventoToUpdate.FechaEvento = Evento.FechaEvento;
            eventoToUpdate.HoraInicio = Evento.HoraInicio;
            eventoToUpdate.HoraFin = Evento.HoraFin;
            eventoToUpdate.Descripción = Evento.Descripción;
            eventoToUpdate.IdCampo = Evento.IdCampo;  // Actualizar la relación con el Campo

            try
            {
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!EventoExists(Evento.IdEvento))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            // Redirigir a la página de índice o a otro lugar
            return RedirectToPage("./Index");
        }

        private bool EventoExists(int id)
        {
            return _context.Eventos.Any(e => e.IdEvento == id);
        }
    }
}
