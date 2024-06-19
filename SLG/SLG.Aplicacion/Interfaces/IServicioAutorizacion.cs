public interface IServicioAutorizacion
{
    bool PoseeElPermiso(String permisosUsuario, Permiso aBuscar);
}