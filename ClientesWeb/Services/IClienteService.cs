using ClientesWeb.Models;

namespace ClientesWeb.Services
{
    public interface IClienteService
    {
        Task<List<ClienteQuery>> ObterTodosAsync(int pagina, int itensPorPagina);
        Task<ClienteQuery?> ObterPorIdAsync(Guid id);
        Task<ClienteQuery?> CriarAsync(ClienteCreateCommand cliente);
        Task<ClienteQuery?> AtualizarAsync(ClienteUpdateCommand cliente);
        Task<bool> DeletarAsync(Guid id);
    }
}
