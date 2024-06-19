namespace SLG.Aplicacion;

public class CasoDeUsoTramiteBaja(IMetodosDB metodos, ServicioAutorizacion autorizacion, ServicioActualizacionDeEstado actualizacion){

    public void Ejecutar(int idUsuario, Tramite tramite)
    {
        if (autorizacion.PoseeElPermiso(metodos.BuscarUsuario(idUsuario).permisos, Permiso.TramiteBaja))
        {
            metodos.EliminarTramite(tramite);
            Expediente e = metodos.ConsultaPorId(tramite.ExpedienteId);
            actualizacion.actualizar(e);
        } else throw new AutorizacionException();
        
    }

}