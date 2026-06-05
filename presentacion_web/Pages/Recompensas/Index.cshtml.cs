using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace presentacion_web.Pages.Recompensas;

public class IndexModel : PageModel
{
    public IActionResult OnGet()
    {
        if (string.IsNullOrEmpty(HttpContext.Session.GetString("JWToken")))
            return RedirectToPage("/Login");
        return Page();
    }
}