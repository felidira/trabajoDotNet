namespace SLG.Aplicacion;

class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    bool PoseeElPermiso(int idUsuario) => (idUsuario == 1) ? true : false;
}