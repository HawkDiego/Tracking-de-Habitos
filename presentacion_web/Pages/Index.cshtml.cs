using Microsoft.AspNetCore.Mvc.RazorPages;

namespace presentacion_web.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            // Aquí validaremos la Sesión más adelante para que no entren sin loguearse
            // Y aquí mismo haremos el llamado asíncrono a la API de Auditorías
        }
    }
}