namespace SLG.Aplicacion;

public class CasoDeUsoTramiteBaja(IContextDB context, ServicioAutorizacionProvisorio autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario, Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(idUsuario))
        {
            context.EliminarTramite(tramite);
            Expediente e = context.ConsultaPorId(tramite.ExpedienteId);
            e.listaTramites=context.ConsultaPorIdExpediente(e.id);
            actualizacion.actualizar(e);
        } else throw new AutorizacionException();
        
    }

}