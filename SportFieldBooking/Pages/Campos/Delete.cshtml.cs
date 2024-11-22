using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Campos
{
    public class DeleteModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public DeleteModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Campo Campo { get; set; }

        public async Task<IActionResult> OnGetAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campo = await _context.Campos.FindAsync(id);

            if (Campo == null)
            {
                return NotFound();
            }

            return Page();
        }

        public async Task<IActionResult> OnPostAsync(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            Campo = await _context.Campos.FindAsync(id);

            if (Campo != null)
            {
                _context.Campos.Remove(Campo);
                await _context.SaveChangesAsync();
            }

            return RedirectToPage("./Index");
        }
    }
}
