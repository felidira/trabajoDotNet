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
                usuario.Contrasenia= Convert.ToBase64String(hasher.ComputeHash(aux));
            }
            if (metodos.ComprobarUsuario(usuario))
                r=true; // existe un usuario con el mismo correo y contraseña
        } else throw new Exception("el correo ingresado no existe.");
        return r;
    }
}