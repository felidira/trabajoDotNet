using SLG.Aplicacion;

public class CasoDeUsoUsuarioListarPermisos(IUsuarioRepositorio repoU){
    public List<string> Ejecutar(Usuario usuario){
        return  repoU.ListarPermisos(usuario);
    }
}