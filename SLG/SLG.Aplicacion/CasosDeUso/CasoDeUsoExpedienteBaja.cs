namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteBaja(IMetodosDB metodos, ServicioAutorizacion autorizacion){
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(metodos.BuscarUsuario(idUsuario).permisos, Permiso.ExpedienteBaja)){
            metodos.EliminarExpediente(expediente);
        } else throw new AutorizacionException();
    }
}