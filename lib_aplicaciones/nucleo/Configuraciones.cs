namespace lib_aplicaciones.nucleo;

public class Configuraciones
{
    public static string obtener(string clave)
    {
        return "server=localhost,1433;User Id=sa;Password=TuPassword123!;TrustServerCertificate=true;Encrypt=False;database=tracking__habitos;";
    }
}
