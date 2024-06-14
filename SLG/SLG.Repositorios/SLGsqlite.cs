namespace SLG.Repositorios;

public class SLGsqlite {
    public static void Inicializar() {
        using var context = new SLGContext();
        if (context.Database.EnsureCreated()){
            Console.WriteLine("se creó la base de datos");
        }
    }
}