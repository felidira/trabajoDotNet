namespace SLG.Aplicacion;

public interface IServicioSesion
{
    Usuario? usuarioLoggeado {get; set;}
    bool conectado {get; set;}
    void Logout();
}