using SLG.Aplicacion;

public class CasoDeUsoTramiteListar (IMetodosDB metodos){
    public List<Tramite> Ejecutar()
    {
        return metodos.ConsultaTodosTramite();
    }
}