namespace SLG.Aplicacion;

public class CasoDeUsoUsuarioEliminarPermiso(IUsuarioRepositorio repoU)
{
    public void Ejecutar(int idUsuario, Permiso aEliminar){
        repoU.EliminarPermiso(idUsuario,aEliminar);
    }
}
