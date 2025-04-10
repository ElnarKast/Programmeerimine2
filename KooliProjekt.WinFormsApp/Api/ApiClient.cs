using System.Net.Http;
using System.Net.Http.Json;

namespace KooliProjekt.WinFormsApp.Api
{
    public class ApiClient : IApiClient, IDisposable
    {
        private readonly HttpClient _httpClient;

        public ApiClient()
        {
            _httpClient = new HttpClient();
            _httpClient.BaseAddress = new Uri("https://localhost:7136/api/Building/");
        }

        public async Task<Result<List<Building>>> List()
        {
            try
            {
                var result = await _httpClient.GetFromJsonAsync<List<Building>>("");

                if (result == null || result.Count == 0)
                {
                    return Result<List<Building>>.Failure<List<Building>>("Andmete laadimine ebaõnnestus või andmeid pole.");
                }

                return Result<List<Building>>.Success<List<Building>>(result);
            }
            catch (Exception ex)
            {
                return Result<List<Building>>.Failure<List<Building>>($"Viga andmete laadimisel: {ex.Message}");
            }
        }


        public async Task<Result> Save(Building Building)
        {
            try
            {
                HttpResponseMessage response;
                if (Building.Id == 0)
                {
                    response = await _httpClient.PostAsJsonAsync("", Building);
                }
                else
                {
                    response = await _httpClient.PutAsJsonAsync(Building.Id.ToString(), Building);
                }

                if (!response.IsSuccessStatusCode)
                {
                    var body = await response.Content.ReadAsStringAsync();
                    return Result.Failure($"Ошибка: {response.StatusCode}");
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure(ex.Message);
            }
        }


        public async Task<Result> Delete(int id)
        {
            try
            {
                var response = await _httpClient.DeleteAsync(id.ToString());
                if (!response.IsSuccessStatusCode)
                {
                    return Result.Failure($"Viga kustutamisel: {response.ReasonPhrase}");
                }

                return Result.Success();
            }
            catch (Exception ex)
            {
                return Result.Failure($"Viga kustutamisel: {ex.Message}");
            }
        }

        public void Dispose()
        {
            _httpClient.Dispose();
        }
    }
}