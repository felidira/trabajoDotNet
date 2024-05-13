namespace SLG.Aplicacion;

public class CasoDeUsoTramiteBaja(ITramiteRepositorio repoT, IExpedienteRepositorio repoE, ServicioAutorizacionProvisorio autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario, Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(idUsuario))
        {
            repoT.EliminarTramite(tramite);
            Expediente e = repoE.ConsultaPorId(tramite.ExpedienteId);
            e.listaTramites=repoT.ConsultaPorIdExpediente(e.id);
            actualizacion.actualizar(e);
        } else throw new AutorizacionException();
        
    }

}