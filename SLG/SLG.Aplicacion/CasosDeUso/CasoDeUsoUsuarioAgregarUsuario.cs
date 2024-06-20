using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
namespace SLG.Aplicacion;


public class CasoDeUsoUsuarioAgregarUsuario(IMetodosDB metodos,ValidadorUsuario validador)
{
    public void Ejecutar(Usuario usuario){
        if (!validador.existe(usuario)){
            Encoding enc = Encoding.UTF8;
            using (SHA256 hasher = SHA256.Create()){
                byte[] aux = enc.GetBytes(usuario.Contrasenia);
                usuario.Contrasenia= Convert.ToBase64String(hasher.ComputeHash(aux));
            }
            metodos.AgregarUsuario(usuario);
        } else throw new Exception("el correo ya está utilizado");
    }
}