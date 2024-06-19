namespace SLG.Aplicacion;

public class CasoDeUsoUsuarioAgregarPermiso(IMetodosDB metodos)
{
    public void Ejecutar(int idUsuario,Permiso Aagregar){
        metodos.AgregarPermiso(idUsuario,Aagregar);
    }
}