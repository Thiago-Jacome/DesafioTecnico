using DesafioTecnico.Database;
using DesafioTecnico.DTOs.Responses;
using DesafioTecnico.Repositories.Interfaces;
using MySql.Data.MySqlClient;

namespace DesafioTecnico.Repositories.Implementacoes
{
    public class ProfessorRepository(MySqlConnectionFactory connection) : IProfessorRepository
    {
        public async Task<List<RetornoProfessorDto>> BuscarProfessoresAsync()
        {
            await using var conn = connection.CreateConnection("Desafio");

            const string qry = """
                SELECT 
                    p.recno AS Id, 
                    p.nome_professor AS NomeProfessor, 
                    p.id_curso AS CursoId, 
                    COALESCE(c.nome_cursos, '') AS NomeCurso
                FROM tblprofessor p
                LEFT JOIN tblcursos c ON p.id_curso = c.recno
                """;

            await using var cmd = new MySqlCommand(qry, conn);
            await conn.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            var lista = new List<RetornoProfessorDto>();
            while (await reader.ReadAsync())
            {
                lista.Add(new RetornoProfessorDto
                {
                    Id = Convert.ToInt32(reader["Id"]),
                    NomeProfessor = reader["NomeProfessor"]?.ToString() ?? string.Empty,
                    CursoId = reader["CursoId"] != DBNull.Value ? Convert.ToInt32(reader["CursoId"]) : 0,
                    NomeCurso = reader["NomeCurso"]?.ToString() ?? string.Empty
                });
            }

            return lista;
        }

        public async Task<RetornoProfessorDto?> BuscarProfessorPorIdAsync(int id)
        {
            await using var conn = connection.CreateConnection("Desafio");

            const string qry = """
                
                SELECT 
                    p.recno AS Id, 
                    p.nome_professor AS NomeProfessor, 
                    p.id_curso AS CursoId, 
                    COALESCE(c.nome_cursos, '') AS NomeCurso
                FROM tblprofessor p
                LEFT JOIN tblcursos c ON p.id_curso = c.recno
                WHERE p.recno = @Id
                """;

            await using var cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            await using var reader = await cmd.ExecuteReaderAsync();

            if (!await reader.ReadAsync())
                return null;

            return new RetornoProfessorDto
            {
                Id = Convert.ToInt32(reader["Id"]),
                NomeProfessor = reader["NomeProfessor"]?.ToString() ?? string.Empty,
                CursoId = reader["CursoId"] != DBNull.Value ? Convert.ToInt32(reader["CursoId"]) : 0,
                NomeCurso = reader["NomeCurso"]?.ToString() ?? string.Empty
            };
        }

        public async Task<int> CriarProfessorAsync(string nomeProfessor, int cursoId)
        {
            await using var conn = connection.CreateConnection("Desafio");

            const string qry = """
                INSERT INTO tblprofessor (nome_professor, id_curso) VALUES (@Nome, @CursoId);
                SELECT LAST_INSERT_ID();
                """;

            await using var cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@Nome", nomeProfessor);
            cmd.Parameters.AddWithValue("@CursoId", cursoId);

            await conn.OpenAsync();
            var idGerado = Convert.ToInt32(await cmd.ExecuteScalarAsync());
            return idGerado;
        }

        public async Task<bool> DeletarProfessorAsync(int id)
        {
            await using var conn = connection.CreateConnection("Desafio");

            const string qry = "DELETE FROM tblprofessor WHERE recno = @Id";

            await using var cmd = new MySqlCommand(qry, conn);
            cmd.Parameters.AddWithValue("@Id", id);

            await conn.OpenAsync();
            int linhasAfetadas = await cmd.ExecuteNonQueryAsync();
            return linhasAfetadas > 0;
        }
    }
}
