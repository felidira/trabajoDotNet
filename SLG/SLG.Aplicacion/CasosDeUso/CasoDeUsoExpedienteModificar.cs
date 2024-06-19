namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteModificar(IContextDB context,ValidadorExpediente validador,ServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)){
            if (validador.ValidarExp(expediente)) {
                expediente.ultModificacion=DateTime.Now;
                expediente.ultModificacionID=idUsuario;
                context.ModificarExpediente(expediente);
            } throw new ValidacionException();
        } else throw new AutorizacionException();
    }
}