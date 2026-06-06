using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PresentacionWeb.Pages.Notas
{
    public class EditarModel : PageModel
    {
        public IActionResult OnGet()
        {
            if (string.IsNullOrEmpty(HttpContext.Session.GetString("JWToken")))
                return RedirectToPage("/Login");
            return Page();
        }
    }
}