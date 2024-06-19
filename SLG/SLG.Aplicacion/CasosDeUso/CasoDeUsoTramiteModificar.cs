namespace SLG.Aplicacion;

public class CasoDeUsoTramiteModificar(IMetodosDB metodos,ValidadorTramite validador,ServicioAutorizacion autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario,Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(metodos.BuscarUsuario(idUsuario).permisos, Permiso.TramiteModificacion)) {
            if (validador.ValidarTramite(tramite)) {
                tramite.ultModificacion=DateTime.Now;
                tramite.ultModificacionID=idUsuario;
                metodos.ModificarTramite(tramite);
                Expediente e = metodos.ConsultaPorId(tramite.ExpedienteId);
                actualizacion.actualizar(e);
            } else throw new ValidacionException();
        } else throw new AutorizacionException();
    }
}