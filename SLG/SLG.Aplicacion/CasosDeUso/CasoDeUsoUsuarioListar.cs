using SLG.Aplicacion;

public class CasoDeUsoUsuarioListar(IUsuarioRepositorio repoU){
    public List<Usuario> Ejecutar(){
        return repoU.ListarUsuarios();
    }
}