namespace SLG.Aplicacion;

public class CasoDeUsoUsuarioModificar(IMetodosDB metodos){
    public void Ejecutar(Usuario usuario){
        metodos.ModificarUsuario(usuario);
    }
}