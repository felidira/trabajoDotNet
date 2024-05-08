namespace SLG.Aplicacion;

class CasoDeUsoExpedienteBaja(IExpedienteRepositorio repo){
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        ServicioAutorizacionProvicional autorizacion = new ServicioAutorizacionProvicional();
        if (autorizacion.PoseeElPermiso(idUsuario)){
            repo.EliminarExpediente(expediente);
        } else throw new Exception AutorizacionException;
    }
}