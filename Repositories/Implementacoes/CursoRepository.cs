using DesafioTecnico.Database;
using DesafioTecnico.DTOs.Responses;
using DesafioTecnico.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace DesafioTecnico.Repositories.Implementacoes
{
    public class CursoRepository(MySqlConnectionFactory connection) : ICursoRepository
    {
        public async Task<List<RetornoCursosDto>> BuscarCursosAsync()
        {
            await using var conn = connection.CreateConnection("Desafio");

            const string qry = """
                SELECT recno AS Id, nome_cursos AS Ncurso FROM tblcursos
                """;
            await using var cmd = new MySqlCommand(qry, conn);
            await conn.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            var lista = new List<RetornoCursosDto>();

            while (await reader.ReadAsync())
            {
                lista.Add(new RetornoCursosDto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    Ncurso = reader["Ncurso"]?.ToString() ?? string.Empty
                });
            }

            return lista;
        }
    }
}
