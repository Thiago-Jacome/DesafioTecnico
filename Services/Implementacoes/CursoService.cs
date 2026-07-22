using DesafioTecnico.DTOs.Responses;
using DesafioTecnico.Repositories.Interfaces;
using DesafioTecnico.Services.Interfaces;

namespace DesafioTecnico.Services.Implementacoes
{
    public class CursoService(ICursoRepository repository) : ICursoService
    {
        public async Task<List<RetornoCursosDto>> BuscarCursosAsync()
        {
            return await repository.BuscarCursosAsync();
        }
    }
}
