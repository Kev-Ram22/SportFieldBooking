using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Pagos
{
    public class IndexModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public IndexModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        public IList<Pago> Pagos { get; set; }

        public async Task OnGetAsync()
        {
            Pagos = await _context.Pagos
                                  .Include(p => p.Reserva)
                                  .ThenInclude(r => r.Cliente)
                                  .ToListAsync();
        }
    }
}
