namespace SLG.Aplicacion;

public class CasoDeUsoTramiteBaja(IUsuarioRepositorio repoU, ITramiteRepositorio repoT, IExpedienteRepositorio repoE, ServicioAutorizacion autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario, Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(repoU.BuscarUsuario(idUsuario).permisos, Permiso.TramiteBaja))
        {
            repoT.EliminarTramite(tramite);
            Expediente e = repoE.ConsultaPorId(tramite.ExpedienteId);
            actualizacion.actualizar(e);
        } else throw new AutorizacionException();
        
    }

}