using DesafioTecnico.DTOs.Responses;

namespace DesafioTecnico.Repositories.Interfaces
{
    public interface IProfessorRepository
    {
        Task<List<RetornoProfessorDto>> BuscarProfessoresAsync();
        Task<RetornoProfessorDto?> BuscarProfessorPorIdAsync(int id);
        Task<int> CriarProfessorAsync(string nomeProfessor, int cursoId);
        Task<bool> DeletarProfessorAsync(int id);
    }
}
