namespace SLG.Aplicacion;

public class CasoDeUsoTramiteModificar(ITramiteRepositorio repoT, IExpedienteRepositorio repoE, ServicioAutorizacionProvisorio autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario,Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)) {
            tramite.ultModificacion=DateTime.Now;
            tramite.ultModificacionID=idUsuario;
            repoT.ModificarTramite(tramite);
            Expediente e = repoE.ConsultaPorId(tramite.ExpedienteId);
            actualizacion.actualizar(e);
        } else throw new AutorizacionException();
    }
}