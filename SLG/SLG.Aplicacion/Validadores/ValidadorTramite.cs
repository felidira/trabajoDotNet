namespace SLG.Aplicacion;

public class ValidadorTramite{

    public bool ValidarTramite(Tramite tramite)
    {
        return (tramite.contenido != null);
    }
}