using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class AuditoriasServicio : IAuditoriasServicio
{
    private readonly IConexion _conexion;
    public AuditoriasServicio(IConexion conexion) => _conexion = conexion;

    public bool Insertar(Auditorias auditoria)
    {
        _conexion.Set<Auditorias>().Add(auditoria);
        return _conexion.SaveChanges() > 0;
    }

    public List<Auditorias> Listar()
        => _conexion.Set<Auditorias>().OrderByDescending(a => a.FechaAccion).ToList();

    public List<Auditorias> ListarPorUsuario(int usuarioId)
        => _conexion.Set<Auditorias>()
            .Where(a => a.Usuario == usuarioId)
            .OrderByDescending(a => a.FechaAccion)
            .ToList();
}
