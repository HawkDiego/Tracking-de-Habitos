namespace app_library.nucleo;

public class Configuraciones
{
    public static string obtener(string clave)
    {
        return "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;database=tracking_habitos;";;
    }
}
