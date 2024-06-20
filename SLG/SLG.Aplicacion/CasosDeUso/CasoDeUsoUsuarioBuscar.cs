namespace SLG.Aplicacion;

public class CasoDeUsoUsuarioBuscar(IMetodosDB metodos){
    public Usuario Ejecutar(Usuario usuario){
        return metodos.BuscarUsuario(usuario);
    }
}