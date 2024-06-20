namespace SLG.Aplicacion;

public class ServicioActualizacionDeEstado(IMetodosDB metodos, EspecificacionCambioDeEstado especificacion){

    public void actualizar(Expediente expediente)
    {
        var lista = metodos.ConsultaPorIdExpediente(expediente.id);
        EstadoExpediente estadoExpediente=especificacion.especificar(lista[lista.Count-1]);
        expediente.estado = (estadoExpediente != 0) ? estadoExpediente : expediente.estado;
        metodos.ModificarExpediente(expediente);
    }
}