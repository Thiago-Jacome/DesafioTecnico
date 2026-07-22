using DesafioTecnico.DTOs.Request;
using DesafioTecnico.DTOs.Responses;

namespace DesafioTecnico.Services.Interfaces
{
    public interface IProfessorService
    {
        Task<List<RetornoProfessorDto>> BuscarProfessoresAsync();
        Task<RetornoProfessorDto?> BuscarProfessorPorIdAsync(int id);
        Task<RetornoProfessorDto> CriarProfessorAsync(CriarProfessorDto dto);
        Task<bool> DeletarProfessorAsync(int id);
    }
}
