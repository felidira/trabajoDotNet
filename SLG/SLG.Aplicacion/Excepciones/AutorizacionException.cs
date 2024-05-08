using System.Collections;

namespace SLG.Aplicacion;

class AutorizacionException : Exception{
    public override string Message => "El usuario intenta realizar una operación para la cual no tiene los permisos necesarios.";
}