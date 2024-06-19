namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteBaja(IContextDB context, ServicioAutorizacion autorizacion){
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)){
            context.EliminarExpediente(expediente);
        } else throw new AutorizacionException();
    }
}