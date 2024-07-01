namespace SLG.Aplicacion;

public class ValidadorUsuario(IUsuarioRepositorio repoU){
    public bool existe(Usuario usuario){
        return repoU.ValidarCorreo(usuario); //verifica que no exista un usuario con el mismo correo
    }
}