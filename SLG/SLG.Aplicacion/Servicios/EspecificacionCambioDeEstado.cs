namespace SLG.Aplicacion;
public class EspecificacionCambioDeEstado{

    public EstadoExpediente especificar(Tramite tramite){
        EstadoExpediente devolver= 0;
        if (tramite.tipoTramite == EtiquetaTramite.Resolución){
            devolver=EstadoExpediente.Con_resolución;
        } else if (tramite.tipoTramite == EtiquetaTramite.Pase_a_estudio){
            devolver=EstadoExpediente.Para_resolver;
        } else if (tramite.tipoTramite == EtiquetaTramite.Pase_al_archivo){
            devolver=EstadoExpediente.Finalizado;
        }
        return devolver;
    }

}