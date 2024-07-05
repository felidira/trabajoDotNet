using System.Runtime.Intrinsics.Arm;
using System.Security.Cryptography;
using System.Text;
namespace SLG.Aplicacion;


public class CasoDeUsoUsuarioAgregarUsuario(IUsuarioRepositorio repoU,ValidadorUsuario validador)
{
    public void Ejecutar(Usuario usuario){
        if (!validador.existe(usuario)){
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
                if (repoU.ListarUsuarios().Count() == 0){
                    nue.permisos+="TramiteModificacion,ExpedienteModificacion,ExpedienteBaja,ExpedienteAlta,TramiteAlta,TramiteBaja";
                }
                repoU.AgregarUsuario(nue);
            }
        } else throw new Exception("el correo ya está utilizado");
    }
}