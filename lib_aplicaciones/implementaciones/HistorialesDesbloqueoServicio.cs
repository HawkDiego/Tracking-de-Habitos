using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class HistorialesDesbloqueoServicio : ServicioBase<HistorialesDesbloqueo>, IHistorialesDesbloqueoServicio
{
    public HistorialesDesbloqueoServicio(IConexion conexion) : base(conexion) { }
}
