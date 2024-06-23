using SLG.Aplicacion;

public class CasoDeUsoUsuarioListar(IMetodosDB metodos){
    public List<Usuario> Ejecutar(){
        return metodos.ListarUsuarios();
    }
}