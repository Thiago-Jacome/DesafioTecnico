using MySql.Data.MySqlClient;
namespace DesafioTecnico.Database
{
    public class MySqlConnection(IConfiguration configuration)
    {
        public MySqlConnection CreatConnection(string banco)
        {
            var connectionString = configuration.GetConnectionString(banco)
            ?? throw new InvalidOperationException($"Connection string '{banco}' não configurada.");
            return new MySqlConnection(connectionString);
        }
    }
}
