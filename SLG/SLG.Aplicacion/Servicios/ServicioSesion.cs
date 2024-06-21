namespace SLG.Aplicacion;

public class ServicioSesion : IServicioSesion
{
    public Usuario? usuarioLoggeado {get; set;}
    public bool conectado {get; set;}
    public void Logout(){
        usuarioLoggeado=null;
        conectado=false;
    }
}