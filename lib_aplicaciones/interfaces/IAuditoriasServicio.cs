using lib_aplicaciones.entidades;

namespace lib_aplicaciones.interfaces;

public interface IAuditoriasServicio
{
    bool             Insertar(Auditorias auditoria);
    List<Auditorias> Listar();
    List<Auditorias> ListarPorUsuario(int usuarioId);
}
