using ClientesWeb.Models;
using System.Net.Http;
using System.Net.Http.Json;

namespace ClientesWeb.Services
{
    public class ClienteService : IClienteService
    {
        private readonly HttpClient _http;
        private const string _resource = "/api/clientes";

        public ClienteService(HttpClient http)
        {
            _http = http;
        }

        public async Task<List<ClienteQuery>> ObterTodosAsync(int pagina, int itensPorPagina)
        {
            try
            {
                var response = await _http.GetFromJsonAsync<List<ClienteQuery>>($"{_resource}/{pagina}/{itensPorPagina}");
                return response ?? new List<ClienteQuery>();
            }
            catch (Exception) 
            {
                return new List<ClienteQuery>();
            }
        }

        public async Task<ClienteQuery?> ObterPorIdAsync(Guid id)
        {
            return await _http.GetFromJsonAsync<ClienteQuery>($"{_resource}/{id}");
        }

        public async Task<ClienteQuery?> CriarAsync(ClienteCreateCommand cliente)
        {
            var response = await _http.PostAsJsonAsync(_resource, cliente);
            return await response.Content.ReadFromJsonAsync<ClienteQuery>();
        }

        public async Task<ClienteQuery?> AtualizarAsync(ClienteUpdateCommand cliente)
        {
            var response = await _http.PutAsJsonAsync(_resource, cliente);
            return await response.Content.ReadFromJsonAsync<ClienteQuery>();
        }

        public async Task<bool> DeletarAsync(Guid id)
        {
            var response = await _http.DeleteAsync($"{_resource}/{id}");
            return response.IsSuccessStatusCode;
        }
    }
}
