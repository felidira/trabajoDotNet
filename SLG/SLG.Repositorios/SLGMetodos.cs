using Microsoft.EntityFrameworkCore;
using SLG.Aplicacion;
using System.Linq;

namespace SLG.Repositorios;

public class SLGMetodos(SLGContext context) : IMetodosDB
{
    public void AgregarExpediente(Expediente expediente)
    {
        context.Add(expediente);
        context.SaveChanges();
    }

    public void AgregarTramite(Tramite tramite)
    {
        context.Add(tramite);
        context.SaveChanges();
    }

    public List<Tramite> ConsultaPorEtiqueta(EtiquetaTramite etiqueta)
    {
        var aux= context.Tramites.Where(t => t.tipoTramite==etiqueta).ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;
    }
    public Expediente ConsultaPorId(int expedienteId)
    {   
        var aux= context.Expedientes.Where(e => e.id==expedienteId).SingleOrDefault();
        if (aux == null) {
            throw new RepositorioException();
        }
        return aux;
    }

    public List<Tramite> ConsultaPorIdExpediente(int idExpediente)
    {
        var aux = context.Tramites.Where(t => t.ExpedienteId==idExpediente).ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;   
    }

    public List<Expediente> ConsultaTodos()
    {
        var aux = context.Expedientes.Select(n => n).ToList();
        if (aux == null){
            throw new RepositorioException();
        }
        return aux;
    }

    public void EliminarExpediente(Expediente expediente)
    {
        var aux = context.Expedientes.Where(e => e.id==expediente.id).
                Include(e => e.Tramite).
                SingleOrDefault();
        if (aux != null){
            context.Remove(aux);
        } else throw new RepositorioException();
        context.SaveChanges();
    }

    public void EliminarTramite(Tramite tramite)
    {
        var aux = context.Tramites.Where(t => t.id == tramite.id).SingleOrDefault();
        if (aux != null){
            context.Remove(aux);
        } else throw new RepositorioException();
        context.SaveChanges();
    }

    public void ModificarExpediente(Expediente expediente)
    {
        var aux = context.Expedientes.Where(e => e.id == expediente.id).SingleOrDefault();
        if (aux != null){
            aux.caratula=expediente.caratula;
            aux.ultModificacionID=expediente.ultModificacionID;
            aux.ultModificacion=expediente.ultModificacion;
        } else throw new RepositorioException();
        context.SaveChanges();
    }

    public void ModificarTramite(Tramite tramite)
    {
        var aux = context.Tramites.Where(t => t.id == tramite.id).SingleOrDefault();
        if (aux != null){
            aux.tipoTramite = tramite.tipoTramite;
            aux.contenido = tramite.contenido;
            aux.ultModificacion= tramite.ultModificacion;
            aux.ultModificacionID = tramite.ultModificacionID;
        } else throw new RepositorioException();
        context.SaveChanges();
    }

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
            usuario.permisos += Aagregar+",";
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
                final += st;                           //cargo el string con los permisos resultantes;
            }
            usuario.permisos=final;                    //salvo los nuevos permisos del usuario
            context.SaveChanges();                     //si no encuentra el permiso a eliminar, no hace NADA.
        }
    }

    public bool ValidarCorreo(Usuario usuario)
    {
        return context.Usuarios.SingleOrDefault(u => u.Correo.Equals(usuario.Correo)) != null;
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
}