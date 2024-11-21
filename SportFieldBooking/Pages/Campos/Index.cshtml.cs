using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Campos
{
    public class IndexModel : PageModel
    {
		private readonly SportFieldBookingContext _context;

		public IndexModel(SportFieldBookingContext context)
		{
			_context = context;
		}

		// Lista de campos para la vista
		public IList<Campo> Campos { get; set; }

		public async Task OnGetAsync()
		{
			if (_context.Campos != null) {
				Campos = await _context.Campos.ToListAsync();
			}
		}
	}
}
