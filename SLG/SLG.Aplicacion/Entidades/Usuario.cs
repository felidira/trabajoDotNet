namespace SLG.Aplicacion;

public class Usuario{
    public string Nombre { get; set;}
    public string Apellido { get; set;}
    public string Correo { get; set;}
    public string Contrasenia { get; set;}
    public List<Permiso>? permisos; 

    public Usuario(string nombre, string apellido, string correo, string contrasenia)
    {
        Apellido=apellido;
        Nombre=nombre;
        Correo=correo;
        Contrasenia=contrasenia;
    }

}