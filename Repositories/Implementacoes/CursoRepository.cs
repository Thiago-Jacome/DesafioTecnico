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

        public async Task<int> CriarCursoAsync(string nomeCurso)
        {
            await using var conn = connection.CreateConnection("desafio");
            const string qry = """

                INSERT INTO tblcursos (nome_cursos) values (@Nome);
                Select LAST_INSERT_ID();
                """;
            await using var cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@Nome", nomeCurso);
            await conn.OpenAsync();
            var idGerado = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return idGerado;
        }
    // Metodo para excluir do banco
    public async Task<bool> DeletarCursoAsync(int id)
        {
            await using var conn = connection.CreateConnection("desafio");
            const string qry = "DELETE FROM tblcursos WHERE recno = Id";

            await using var cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            int linhasAfetadas = await cmd.ExecuteNonQueryAsync();

            return linhasAfetadas > 0;
          
        }
    }

}
