using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.ComponentModel.DataAnnotations;
using System.Net.Http.Json;
using System.Text.Json;

namespace presentacion_web.Pages
{
    public class LoginModel : PageModel
    {
        private readonly IHttpClientFactory _httpClientFactory;

        public LoginModel(IHttpClientFactory httpClientFactory)
        {
            _httpClientFactory = httpClientFactory;
        }

        [BindProperty]
        public LoginInput Input { get; set; } = new LoginInput();

        public string MensajeError { get; set; } = string.Empty;

        public class LoginInput
        {
            [Required(ErrorMessage = "El correo es obligatorio.")]
            public string Email { get; set; } = string.Empty;

            [Required(ErrorMessage = "La contraseña es obligatoria.")]
            [DataType(DataType.Password)]
            public string Clave { get; set; } = string.Empty;
        }

        public class LoginResponse
        {
            public UsuarioDto? Usuario { get; set; }
            public string Token { get; set; } = string.Empty;
        }

        public class UsuarioDto
        {
            public int Id { get; set; }
            public string? Nombre { get; set; }
            public string? Email { get; set; }
            public int? xpTotal { get; set; }
            public int? Nivel { get; set; }
        }

        public IActionResult OnGet()
        {
            if (!string.IsNullOrEmpty(HttpContext.Session.GetString("JWToken")))
                return RedirectToPage("Index");

            MensajeError = string.Empty;
            return Page();
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
                return Page();

            try
            {
                var handler = new HttpClientHandler();
                handler.ServerCertificateCustomValidationCallback =
                    HttpClientHandler.DangerousAcceptAnyServerCertificateValidator;
                var client = new HttpClient(handler);
                client.Timeout = TimeSpan.FromSeconds(10);

                var response = await client.PostAsJsonAsync(
                    "http://localhost:5165/Usuarios/Login",
                    new { email = Input.Email, clave = Input.Clave }
                );

                if (response.IsSuccessStatusCode)
                {
                    var data = await response.Content.ReadFromJsonAsync<LoginResponse>(
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }
                    );

                    if (data?.Token is not null)
                    {
                        HttpContext.Session.SetString("JWToken", data.Token);
                        HttpContext.Session.SetString("UsuarioNombre", data.Usuario?.Nombre ?? "Usuario");
                        HttpContext.Session.SetInt32("UsuarioId", data.Usuario?.Id ?? 0);
                        return RedirectToPage("Index");
                    }
                }

                if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    MensajeError = "Correo o contraseña incorrectos.";
                else
                    MensajeError = $"Error del servidor: {(int)response.StatusCode}";

                return Page();
            }
            catch (TaskCanceledException)
            {
                MensajeError = "El servidor tardó demasiado. ¿Está corriendo la API?";
                return Page();
            }
            catch (HttpRequestException)
            {
                MensajeError = "No se pudo conectar con el servidor.";
                return Page();
            }
            catch (Exception ex)
            {
                MensajeError = $"Error: {ex.Message}";
                return Page();
            }
        }
    }
}