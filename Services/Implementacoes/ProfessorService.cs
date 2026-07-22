using DesafioTecnico.DTOs.Request;
using DesafioTecnico.DTOs.Responses;
using DesafioTecnico.Repositories.Interfaces;
using DesafioTecnico.Services.Interfaces;

namespace DesafioTecnico.Services.Implementacoes
{
    public class ProfessorService(IProfessorRepository professorRepository) : IProfessorService
    {
        public async Task<List<RetornoProfessorDto>> BuscarProfessoresAsync()
        {
            return await professorRepository.BuscarProfessoresAsync();
        }

        public async Task<RetornoProfessorDto?> BuscarProfessorPorIdAsync(int id)
        {
            if (id <= 0) return null;
            return await professorRepository.BuscarProfessorPorIdAsync(id);
        }

        public async Task<RetornoProfessorDto> CriarProfessorAsync(CriarProfessorDto dto)
        {
            if (string.IsNullOrWhiteSpace(dto.NomeProfessor))
            {
                throw new ArgumentException("O nome do professor não pode ser vazio.");
            }

            if (dto.CursoId <= 0)
            {
                throw new ArgumentException("O ID do curso deve ser um valor válido.");
            }

            int idGerado = await professorRepository.CriarProfessorAsync(dto.NomeProfessor, dto.CursoId);

            var professorCriado = await professorRepository.BuscarProfessorPorIdAsync(idGerado);
            return professorCriado ?? new RetornoProfessorDto
            {
                Id = idGerado,
                NomeProfessor = dto.NomeProfessor,
                CursoId = dto.CursoId
            };
        }

        public async Task<bool> DeletarProfessorAsync(int id)
        {
            if (id <= 0) return false;
            return await professorRepository.DeletarProfessorAsync(id);
        }
    }
}
