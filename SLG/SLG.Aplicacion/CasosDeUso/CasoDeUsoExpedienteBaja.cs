namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteBaja(IContextDB context, ServicioAutorizacionProvisorio autorizacion){
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)){
            expediente.listaTramites=context.ConsultaPorIdExpediente(expediente.id);
            foreach (Tramite t in expediente.listaTramites){
                context.EliminarTramite(t);
            }
            context.EliminarExpediente(expediente);
        } else throw new AutorizacionException();
    }
}