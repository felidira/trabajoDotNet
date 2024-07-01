using SLG.Aplicacion;

public class CasoDeUsoTramiteListar (ITramiteRepositorio repoT){
    public List<Tramite> Ejecutar()
    {
        return repoT.ConsultaTodosTramite();
    }
}