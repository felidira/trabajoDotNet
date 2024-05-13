namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoE, ITramiteRepositorio repoT, ServicioAutorizacionProvisorio autorizacion){
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)){
            expediente.listaTramites=repoT.ConsultaPorIdExpediente(expediente.id);
            foreach (Tramite t in expediente.listaTramites){
                repoT.EliminarTramite(t);
            }
            repoE.EliminarExpediente(expediente);
        } else throw new AutorizacionException();
    }
}