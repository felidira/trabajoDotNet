namespace SLG.Aplicacion;

public class CasoDeUsoTramiteModificar(ITramiteRepositorio repoT,ValidadorTramite validador, IExpedienteRepositorio repoE, ServicioAutorizacionProvisorio autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario,Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)) {
            if (validador.ValidarTramite(tramite)) {
                tramite.ultModificacion=DateTime.Now;
                tramite.ultModificacionID=idUsuario;
                repoT.ModificarTramite(tramite);
                Expediente e = repoE.ConsultaPorId(tramite.ExpedienteId);
                e.listaTramites=repoT.ConsultaPorIdExpediente(e.id);
                actualizacion.actualizar(e);
            } else throw new ValidacionException();
        } else throw new AutorizacionException();
    }
}