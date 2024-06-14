namespace SLG.Aplicacion;

public class ServicioAutorizacionProvisorio : IServicioAutorizacion
{
    public bool PoseeElPermiso(int idUsuario) => (idUsuario == 1) ? true : false;
} 