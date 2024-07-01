namespace SLG.Aplicacion;

public class CasoDeUsoTramiteModificar(IUsuarioRepositorio repoU, IExpedienteRepositorio repoE, ITramiteRepositorio repoT, ValidadorTramite validador,ServicioAutorizacion autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario,Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(repoU.BuscarUsuario(idUsuario).permisos, Permiso.TramiteModificacion)) {
            if (validador.ValidarTramite(tramite)) {
                tramite.ultModificacion=DateTime.Now;
                tramite.ultModificacionID=idUsuario;
                repoT.ModificarTramite(tramite);
                Expediente e = repoE.ConsultaPorId(tramite.ExpedienteId);
                actualizacion.actualizar(e);
            } else throw new ValidacionException();
        } else throw new AutorizacionException();
    }
}