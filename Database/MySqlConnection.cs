using MySql.Data.MySqlClient;

namespace DesafioTecnico.Database
{
    public class MySqlConnectionFactory(IConfiguration configuration)
    {
        public MySqlConnection CreateConnection(string banco)
        {
            var connectionString = configuration.GetConnectionString(banco)
            ?? throw new InvalidOperationException($"Connection string '{banco}' não configurada.");
            
            return new MySqlConnection(connectionString);
        }
    }
}
