using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SportFieldBooking.Data;
using SportFieldBooking.Models;

namespace SportFieldBooking.Pages.Campos
{
    public class CreateModel : PageModel
    {
        private readonly SportFieldBookingContext _context;

        public CreateModel(SportFieldBookingContext context)
        {
            _context = context;
        }

        public IActionResult OnGet()
        {
            return Page();
        }

        [BindProperty]
        public Campo Campo { get; set; } = default;

        public async Task<IActionResult> OnPostAsync()
        {
            _context.Campos.Add(Campo);
            await _context.SaveChangesAsync();

            return RedirectToPage("./Index");
        }
    }
}
