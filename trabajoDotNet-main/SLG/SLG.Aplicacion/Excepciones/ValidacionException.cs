namespace SLG.Aplicacion;

class ValidacionException : Exception{
    public override string Message => "La entidad no cumple con los requisitos.";
}