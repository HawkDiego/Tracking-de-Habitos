using lib_aplicaciones.entidades;
using lib_aplicaciones.interfaces;

namespace lib_aplicaciones.implementaciones;

public class CategoriasServicio : ServicioBase<Categorias>, ICategoriasServicio
{
    public CategoriasServicio(IConexion conexion) : base(conexion) { }
}
