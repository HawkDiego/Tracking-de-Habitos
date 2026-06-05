using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class RecordatoriosServicio : ServicioBase<Recordatorios>, IRecordatoriosServicio
{
    public RecordatoriosServicio(IConexion conexion) : base(conexion) { }
}
