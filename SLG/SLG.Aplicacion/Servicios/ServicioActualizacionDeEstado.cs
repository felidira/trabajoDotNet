namespace SLG.Aplicacion;

public class ServicioActualizacionDeEstado(EspecificacionCambioDeEstado especificacion,IExpedienteRepositorio repoE){

    public void actualizar(Expediente expediente)
    {
        EstadoExpediente estadoExpediente=especificacion.especificar(expediente.listaTramites[expediente.listaTramites.Count()-1]);
        expediente.estado = (estadoExpediente != 0) ? estadoExpediente : expediente.estado;
        repoE.ModificarExpediente(expediente);
    }
}