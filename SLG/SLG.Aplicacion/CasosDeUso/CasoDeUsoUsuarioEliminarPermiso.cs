namespace SLG.Aplicacion;

public class CasoDeUsoUsuarioEliminarPermiso(IMetodosDB metodos)
{
    public void Ejecutar(int idUsuario, Permiso aEliminar){
        metodos.EliminarPermiso(idUsuario,aEliminar);
    }
}
