namespace SLG.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(IContextDB context){

    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
    {
        return context.ConsultaPorEtiqueta(etiqueta);
    }
}