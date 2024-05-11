namespace SLG.Aplicacion;

class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo, ServicioAutorizacionProvisorio autorizacion){
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)){
            repo.EliminarExpediente(expediente.id);
        } else throw new AutorizacionException();
    }
}