using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Authorization;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Reservas
{
    [Authorize]
    public class IndexModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public IndexModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        public IList<Reserva> Reservas { get; set; }

        public async Task OnGetAsync()
        {
            Reservas = await _context.Reservas
                             .Include(r => r.Campo)  
                             .Include(r => r.Cliente)
                             .ToListAsync();
        }
    }
}
