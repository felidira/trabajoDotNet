using System.Security.Cryptography;
using System.Text;

namespace SLG.Aplicacion;

public class CasoDeUsoUsuarioModificar(IMetodosDB metodos){
    public void Ejecutar(Usuario usuario){
        Encoding enc = Encoding.UTF8;
        using (SHA256 hasher = SHA256.Create()){
            byte[] aux = enc.GetBytes(usuario.Contrasenia);
            string hashedpw= Convert.ToBase64String(hasher.ComputeHash(aux));
            usuario.Contrasenia=hashedpw;
        }
        metodos.ModificarUsuario(usuario);
    }
}