using DesafioTecnico.DTOs.Responses;

namespace DesafioTecnico.Repositories.Interfaces;

public interface ICursoRepository
{
    Task<List<RetornoCursosDto>> BuscarCursosAsync();
}
