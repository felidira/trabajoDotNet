using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
namespace SLG.Aplicacion;

public class CasoDeUsoUsuarioIniciarSesion(IMetodosDB metodos,ValidadorUsuario validadorCorreo)
{
    public bool Ejecutar(Usuario usuario){
        bool r=false;
        if (validadorCorreo.existe(usuario)){
            Encoding enc = Encoding.UTF8;
            using (SHA256 hasher = SHA256.Create()){
                byte[] aux = enc.GetBytes(usuario.Contrasenia);
                string hashedpw= Convert.ToBase64String(hasher.ComputeHash(aux));
                Usuario nue = new Usuario()
                {
                    Contrasenia = hashedpw,
                    Correo = usuario.Correo,
                    Nombre = usuario.Nombre,
                    Apellido = usuario.Apellido,
                    id = usuario.id,
                    permisos = usuario.permisos
                };
                if (metodos.ComprobarUsuario(nue))
                    r=true;
                else throw new Exception("Los datos ingresados no son correctos");
            }
        } else throw new Exception("El correo ingresado no existe.");
        return r;
    }
}