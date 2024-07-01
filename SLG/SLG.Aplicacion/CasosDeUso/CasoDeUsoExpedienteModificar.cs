namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteModificar(IUsuarioRepositorio repoU, IExpedienteRepositorio repoE, ValidadorExpediente validador,ServicioAutorizacion autorizacion)
{
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(repoU.BuscarUsuario(idUsuario).permisos, Permiso.ExpedienteModificacion)){
            if (validador.ValidarExp(expediente)) {
                expediente.ultModificacion=DateTime.Now;
                expediente.ultModificacionID=idUsuario;
                repoE.ModificarExpediente(expediente);
            } throw new ValidacionException();
        } else throw new AutorizacionException();
    }
}