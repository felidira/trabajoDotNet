namespace SLG.Aplicacion;

public class ServicioActualizacionDeEstado(IExpedienteRepositorio repoE, ITramiteRepositorio repoT, EspecificacionCambioDeEstado especificacion){

    public void actualizar(Expediente expediente)
    {
        var lista = repoT.ConsultaPorIdExpediente(expediente.id);
        EstadoExpediente estadoExpediente=especificacion.especificar(lista[lista.Count-1]);
        expediente.estado = (estadoExpediente != 0) ? estadoExpediente : expediente.estado;
        repoE.ModificarExpediente(expediente);
    }
}