using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Text;
using System.Threading.Tasks;

namespace KooliProjekt.BlazorApp.Api
{
    public class ApiClient : IApiClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7136/api/Buildings/");
        }

        public async Task<IList<Building>> List()
        {
            var result = await _httpClient.GetFromJsonAsync<List<Building>>("");

            return result;
        }

        public async Task Save(Building list)
        {
            if(list.Id == 0)
            {
                await _httpClient.PostAsJsonAsync("", list);
            }
            else
            {
                await _httpClient.PutAsJsonAsync(list.Id.ToString(), list);
            }
        }

        public async Task Delete(int id)
        {
            await _httpClient.DeleteAsync(id.ToString());
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}
