namespace SLG.Aplicacion;

class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repoE,ITramiteRepositorio repoT, ServicioAutorizacionProvisorio autorizacion){
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)){
            foreach (Tramite t in expediente.listaTramites){
                repoT.EliminarTramite(t);
            }
            repoE.EliminarExpediente(expediente);
        } else throw new AutorizacionException();
    }
}