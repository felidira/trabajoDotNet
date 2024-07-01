namespace SLG.Aplicacion;

public class CasoDeUsoUsuarioAgregarPermiso(IUsuarioRepositorio repoU)
{
    public void Ejecutar(int idUsuario,Permiso Aagregar){
        repoU.AgregarPermiso(idUsuario,Aagregar);
    }
}