namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteBaja(IMetodosDB metodos, ServicioAutorizacion autorizacion){
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)){
            metodos.EliminarExpediente(expediente);
        } else throw new AutorizacionException();
    }
}