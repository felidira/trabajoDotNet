namespace SLG.Aplicacion;

public class CasoDeUsoTramiteModificar(IContextDB context,ValidadorTramite validador,ServicioAutorizacion autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario,Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(idUsuario)) {
            if (validador.ValidarTramite(tramite)) {
                tramite.ultModificacion=DateTime.Now;
                tramite.ultModificacionID=idUsuario;
                context.ModificarTramite(tramite);
                Expediente e = context.ConsultaPorId(tramite.ExpedienteId);
                actualizacion.actualizar(e);
            } else throw new ValidacionException();
        } else throw new AutorizacionException();
    }
}