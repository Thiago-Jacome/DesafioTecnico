using DesafioTecnico.DTOs.Request;
using DesafioTecnico.DTOs.Responses;
using DesafioTecnico.Repositories.Interfaces;
using DesafioTecnico.Services.Interfaces;
using Org.BouncyCastle.Asn1;

namespace DesafioTecnico.Services.Implementacoes
{
    public class CursoService(ICursoRepository repository) : ICursoService
    {
        public async Task<List<RetornoCursosDto>> BuscarCursosAsync()
        {
            return await repository.BuscarCursosAsync();
        }

        public async Task<RetornoCursosDto> CriarCursoAsync(CriarCursoDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.Ncurso))
            {
                throw new ArgumentException("O nome do curso não pode ser vazio.");
            }

            int idGerado = await repository.CriarCursoAsync(dto.Ncurso);
            return new RetornoCursosDto
            {
                Id = idGerado,
                Ncurso = dto.Ncurso
            };
        }
        public async Task<bool> DeletarCursoAsync(int id)
        {
            if (id <= 0)
            {
                return await repository.DeletarCursoAsync(id);
            }
            return true;
        }
    }
}
