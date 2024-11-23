using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace SportFieldBooking.Pages.Account
{
    public class LoginModel : PageModel
    {
        [BindProperty]
        public Models.User User { get; set; }
        public bool LoginFailed { get; set; } = false;

        public IActionResult OnGet()
        {
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            // Validación en memoria (modificar con base de datos más adelante)
            if (User.Email == "correo@gmail.com" && User.Password == "12345")
            {
                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.Name, User.Email),
                };

                var identity = new ClaimsIdentity(claims, "MyCookieAuth");
                ClaimsPrincipal claimsPrincipal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync("MyCookieAuth", claimsPrincipal);

                return RedirectToPage("/Index");
            }

            LoginFailed = true;
            return Page();
        }
    }
}
