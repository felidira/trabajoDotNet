namespace SLG.Aplicacion;
public interface IUsuarioRepositorio{
    Usuario BuscarUsuario(int id);
    void AgregarPermiso(int idUsuario, Permiso Aagregar);
    void EliminarPermiso(int idUsuario, Permiso Aeliminar);
    bool ValidarCorreo(Usuario usuario);
    void AgregarUsuario(Usuario usuario);
    bool ComprobarUsuario(Usuario usuario);
    void ModificarUsuario(Usuario usuario);
    Usuario BuscarUsuario(Usuario usuario);
    List<Usuario> ListarUsuarios();
}