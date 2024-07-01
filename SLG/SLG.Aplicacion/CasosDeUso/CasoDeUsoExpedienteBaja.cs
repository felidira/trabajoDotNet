namespace SLG.Aplicacion;

public class CasoDeUsoExpedienteBaja(IUsuarioRepositorio repoU, IExpedienteRepositorio repoE, ServicioAutorizacion autorizacion){
    public void Ejecutar(int idUsuario, Expediente expediente)
    {
        if (autorizacion.PoseeElPermiso(repoU.BuscarUsuario(idUsuario).permisos, Permiso.ExpedienteBaja)){
            repoE.EliminarExpediente(expediente);
        } else throw new AutorizacionException();
    }
}