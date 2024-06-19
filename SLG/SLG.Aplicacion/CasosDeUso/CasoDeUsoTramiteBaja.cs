namespace SLG.Aplicacion;

public class CasoDeUsoTramiteBaja(IContextDB context, ServicioAutorizacion autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario, Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(idUsuario))
        {
            context.EliminarTramite(tramite);
            Expediente e = context.ConsultaPorId(tramite.ExpedienteId);
            actualizacion.actualizar(e);
        } else throw new AutorizacionException();
        
    }

}