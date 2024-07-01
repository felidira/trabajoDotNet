namespace SLG.Aplicacion;

public class CasoDeUsoTramiteConsultaPorEtiqueta(ITramiteRepositorio repoT){

    public List<Tramite> Ejecutar(EtiquetaTramite etiqueta)
    {
        return repoT.ConsultaPorEtiqueta(etiqueta);
    }
}