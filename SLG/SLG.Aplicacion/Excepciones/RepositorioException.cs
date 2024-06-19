namespace SLG.Aplicacion;

public class RepositorioException : Exception{

    public override string Message => "La entidad a la que se intenta acceder no existe en el repositorio correspondiente."; 
}