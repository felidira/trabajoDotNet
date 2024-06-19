namespace SLG.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(IMetodosDB metodos){

    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
    {
        return metodos.ConsultaPorEtiqueta(etiqueta);
    }
}