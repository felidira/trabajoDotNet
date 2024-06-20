namespace SLG.Aplicacion;

public class ValidadorUsuario(IMetodosDB metodos){
    public bool existe(Usuario usuario){
        return metodos.ValidarCorreo(usuario); //verifica que no exista un usuario con el mismo correo
    }
}