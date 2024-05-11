namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteAlta(IExpedienteRepositorio repo, ServicioAutorizacionProvisorio autorizacion)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario))
        {
            expediente.fechaCreacion=DateTime.Now;
            expediente.ultModificacion=expediente.fechaCreacion;
            expediente.ultModificacionID=idUsuario;
            repo.AgregarExpediente(expediente);
        } else throw new AutorizacionException();
    }
}