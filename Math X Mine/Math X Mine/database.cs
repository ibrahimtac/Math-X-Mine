using MySql.Data.MySqlClient;

public class Database
{
    private static string connectionString = "Server=localhost;Database=mathxmine;User ID=root;Password=;";

    // Bağlantı nesnesi döndüren bir metot
    public static MySqlConnection GetConnection()
    {
        MySqlConnection conn = new MySqlConnection(connectionString);
        conn.Open();
        return conn;
    }
}
