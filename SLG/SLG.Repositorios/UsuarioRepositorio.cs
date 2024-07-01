using Microsoft.EntityFrameworkCore;
using SLG.Aplicacion;
using System.Linq;
namespace SLG.Repositorios;

public class UsuarioRepositorio(SLGContext context) : IUsuarioRepositorio {
    public Usuario BuscarUsuario(int idABuscar){
        var aux = context.Usuarios.Where(u => u.id == idABuscar).SingleOrDefault();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;
    }

    public void AgregarPermiso(int idUsuario, Permiso Aagregar)
    {
        var usuario = context.Usuarios.Where(u => u.id == idUsuario).SingleOrDefault();
        if (usuario!=null){
            var l= usuario.permisos.Split(",").ToList();
            if (!l.Contains(Aagregar.ToString())){
                Console.WriteLine(usuario.id+" está agregando permisos");
                usuario.permisos += Aagregar.ToString()+",";
                Console.WriteLine(usuario.permisos);
            } else {
                Console.WriteLine("el usuario intenta agregar un permiso que ya tiene");
                throw new Exception("el usuario ya posee el permiso.");
            }
        } else throw new RepositorioException();
        context.SaveChanges();
    }

    public void EliminarPermiso(int idUsuario, Permiso Aeliminar)
    {
        var usuario = context.Usuarios.Where(u => u.id == idUsuario).SingleOrDefault();
        if (usuario!=null){
            string[] aux= usuario.permisos.Split(","); //aux = array de permisos que tiene el usuario
            List<string> auxl= aux.ToList();           //guardo en auxl una lista auxiliar para poder asi
            auxl.Remove(Aeliminar.ToString());         //eliminar el permiso con el .Remove
            string final="";                           //string para sobreescribir permisos del usuario
            foreach (string st in auxl){
                final += st+",";                           //cargo el string con los permisos resultantes;
            }
            if (string.IsNullOrWhiteSpace(final) || final.Replace(",", "").Length == 0) { 
                Console.WriteLine(final); 
                final="";
                Console.WriteLine(final);
            }
            usuario.permisos=final;                    //salvo los nuevos permisos del usuario
            context.SaveChanges();                     //si no encuentra el permiso a eliminar, no hace NADA.
        }
    }
    public void AgregarUsuario(Usuario usuario)
    {
        context.Usuarios.Add(usuario);
        context.SaveChanges();
    }

    public bool ComprobarUsuario(Usuario usuario)
    {
        return context.Usuarios.SingleOrDefault(u => u.Correo.Equals(usuario.Correo) && u.Contrasenia.Equals(usuario.Contrasenia)) != null;
    }
    public void ModificarUsuario(Usuario usuario){
        var u= context.Usuarios.SingleOrDefault(u => u.id==usuario.id);
        //se asume que existe porque se llama desde el panel del usuario que ya tiene el usuario cargado con su ID.
        if (u != null){
            u.Apellido=usuario.Apellido;
            u.Correo=usuario.Correo;
            u.Contrasenia=usuario.Contrasenia;
            u.Nombre=usuario.Nombre;
        }
        context.SaveChanges();
    }

    public Usuario BuscarUsuario(Usuario usuario){
        var u = context.Usuarios.SingleOrDefault(u => u.Correo.Equals(usuario.Correo));
        if (u ==null) throw new RepositorioException();
        return u;
    }
    public List<Usuario> ListarUsuarios()
    {
        var aux = context.Usuarios.Select(u => u).
                    OrderBy(u => u.id).
                    ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;
    }
        public bool ValidarCorreo(Usuario usuario)
    {
        return context.Usuarios.SingleOrDefault(u => u.Correo.Equals(usuario.Correo)) != null;
    }

    public List<string> ListarPermisos(Usuario usuario)
    {
        string[] aux= usuario.permisos.Split(",");
        return aux.ToList();
    }
}