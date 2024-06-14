namespace SLG.Aplicacion;

public class Usuario{
    public string Nombre { get; set;}
    public string Apellido { get; set;}
    public string Correo { get; set;}
    public string Contraseña { get; set;}
    public List<Permiso> permisos; 

}