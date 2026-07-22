using DesafioTecnico.DTOs.Responses;

namespace DesafioTecnico.Repositories.Interfaces;

public interface ICursoRepository
{
    Task<List<RetornoCursosDto>> BuscarCursosAsync();
    Task<int> CriarCursoAsync(string nomeCurso);
    Task<bool> DeletarCursoAsync(int id);
}
