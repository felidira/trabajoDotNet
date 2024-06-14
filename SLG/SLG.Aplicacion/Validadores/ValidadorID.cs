namespace SLG.Aplicacion;

public class ValidadorID {

    public bool ValidarId(int idUsuario) => (idUsuario>=0) ? true : false;

}