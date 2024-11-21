using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Eventos
{
    public class IndexModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public IndexModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        public IList<Evento> Eventos { get; set; }

        public async Task OnGetAsync()
        {
            Eventos = await _context.Eventos
                                    .Include(e => e.Campo)
                                    .ToListAsync();
        }
    }
}
