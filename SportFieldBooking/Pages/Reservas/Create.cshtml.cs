using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Reservas
{
    public class CreateModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public CreateModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Reserva Reserva { get; set; }

        public SelectList Clientes { get; set; }
        public SelectList Campos { get; set; }
        public SelectList Estados { get; set; }

        public async Task<IActionResult> OnGetAsync()
        {
            // Cargar la lista de clientes y campos
            Clientes = new SelectList(await _context.Clientes.ToListAsync(), "IdCliente", "Nombre");
            Campos = new SelectList(await _context.Campos.ToListAsync(), "IdCampo", "Nombre");
            Estados = new SelectList(new[] { "Reservado", "Cancelado", "Completado" });

            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            //if (!ModelState.IsValid)
            //{
            //    return Page();
            //}

            _context.Reservas.Add(Reserva);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
