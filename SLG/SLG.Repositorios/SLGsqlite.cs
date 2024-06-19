using Microsoft.EntityFrameworkCore;

namespace SLG.Repositorios;

public class SLGsqlite {
    public static void Inicializar() {
        using var context = new SLGContext();
        if (context.Database.EnsureCreated()){
            Console.WriteLine("se creó la base de datos");
            var connection = context.Database.GetDbConnection();
            connection.Open();
            using (var command = connection.CreateCommand())
            {
                command.CommandText = "PRAGMA journal_mode=DELETE;";
                command.ExecuteNonQuery();
            }
        }
    }
}