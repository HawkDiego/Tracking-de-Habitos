using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace presentacion_web.Pages.Usuarios;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        var token = HttpContext.Session.GetString("JWToken");
        if (string.IsNullOrEmpty(token))
            return RedirectToPage("/Login");

        return Page();
    }
}