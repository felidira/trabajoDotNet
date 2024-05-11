namespace SLG.Aplicacion;

class CasoDeUsoExpedienteModificar(IExpedienteRepositorio repo, ServicioAutorizacionProvisorio autorizacion)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)){
            expediente.ultModificacion=DateTime.Now;
            expediente.ultModificacionID=idUsuario;
            repo.ModificarExpediente(expediente);
        } else throw new AutorizacionException();
    }
}