namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteModificar(IMetodosDB metodos,ValidadorExpediente validador,ServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(metodos.BuscarUsuario(idUsuario).permisos, Permiso.ExpedienteModificacion)){
            if (validador.ValidarExp(expediente)) {
                expediente.ultModificacion=DateTime.Now;
                expediente.ultModificacionID=idUsuario;
                metodos.ModificarExpediente(expediente);
            } throw new ValidacionException();
        } else throw new AutorizacionException();
    }
}