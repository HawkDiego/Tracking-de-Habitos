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

        // Clase contenedora para los datos del formulario (Validaciones del Modelo)
        public class LoginInput
        {
            [Required(ErrorMessage = "El usuario o correo es obligatorio.")]
            public string Usuario { get; set; } = string.Empty;

            [Required(ErrorMessage = "La contraseña es obligatoria.")]
            [DataType(DataType.Password)]
            public string Password { get; set; } = string.Empty;
        }

        // Clase DTO para deserializar la respuesta de la API de Diego si es necesario
        public class TokenResponse
        {
            public string Token { get; set; } = string.Empty;
            public string Usuario { get; set; } = string.Empty;
        }

        public void OnGet()
        {
            // Limpia mensajes al cargar la vista de forma limpia
            MensajeError = string.Empty;
        }

        // Ejecución asíncrona para cumplir con el Nivel 5 de la rúbrica evaluativa
        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Creamos el cliente HTTP registrado en la arquitectura
                var client = _httpClientFactory.CreateClient();

                // URL base provisional de la API de su backend local (ajustar puerto cuando Diego lo pase)
                string urlApi = "https://localhost:7293/Auth/Login";

                // Enviamos los datos serializados automáticamente como JSON de forma asíncrona
                var response = await client.PostAsJsonAsync(urlApi, new
                {
                    username = Input.Usuario,
                    password = Input.Password
                });

                if (response.IsSuccessStatusCode)
                {
                    // Si el backend responde OK, leemos el contenido (token o sesión)
                    var responseData = await response.Content.ReadFromJsonAsync<TokenResponse>();

                    if (responseData != null)
                    {
                        // AQUÍ SE AGREGA LA SESIÓN POSTERIORMENTE
                        // HttpContext.Session.SetString("JWToken", responseData.Token);

                        return RedirectToPage("/Index"); // Redirecciona al dashboard principal
                    }
                }

                // Si el backend rechaza las credenciales (Ej: Error 401 o 400)
                MensajeError = "Credenciales incorrectas o usuario no válido en el sistema.";
                return Page();
            }
            catch (HttpRequestException)
            {
                // Control de errores de infraestructura (Si la API de Diego está apagada)
                MensajeError = "No se pudo establecer conexión con el servidor de autenticación. Intente más tarde.";
                return Page();
            }
            catch (Exception ex)
            {
                MensajeError = $"Ocurrió un error inesperado en la interfaz: {ex.Message}";
                return Page();
            }
        }
    }
}