using DesafioTecnico.DTOs.Responses;

namespace DesafioTecnico.Services.Interfaces
{
    public interface ICursoService
    {
        Task<List<RetornoCursosDto>> BuscarCursosAsync();
    }
}
