namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteModificar(IExpedienteRepositorio repo,ValidadorExpediente validador, ServicioAutorizacionProvisorio autorizacion)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)){
            if (validador.ValidarExp(expediente)) {
                expediente.ultModificacion=DateTime.Now;
                expediente.ultModificacionID=idUsuario;
                repo.ModificarExpediente(expediente);
            } throw new ValidacionException();
        } else throw new AutorizacionException();
    }
}