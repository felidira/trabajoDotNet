namespace SLG.Aplicacion;

public class CasoDeUsoUsuarioBuscar(IUsuarioRepositorio repoU){
    public Usuario Ejecutar(Usuario usuario){
        return repoU.BuscarUsuario(usuario);
    }
}