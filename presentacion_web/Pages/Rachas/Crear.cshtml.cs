using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace presentacion_web.Pages.Rachas;

public class CrearModel : PageModel
{
    public IActionResult OnGet()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("JWToken")))
            return RedirectToPage("/Login");
        return Page();
    }
}