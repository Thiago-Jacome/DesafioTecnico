using DesafioTecnico.DTOs.Request;
using DesafioTecnico.DTOs.Responses;

namespace DesafioTecnico.Services.Interfaces
{
    public interface ICursoService
    {
        Task<List<RetornoCursosDto>> BuscarCursosAsync();
        Task<RetornoCursosDto> CriarCursoAsync(CriarCursoDto dto);
        Task<bool> DeletarCursoAsync(int id);
    }
}
