using KooliProjekt.BlazorApp.Api;
using System.Net.Http.Json;

public class ApiClient : IApiClient, IDisposable
{
    private readonly HttpClient _httpClient;

    public ApiClient()
    {
        _httpClient = new HttpClient();
        _httpClient.BaseAddress = new Uri("https://localhost:7136/api/");
    }

    public async Task<IList<Building>> List()
    {
        var result = await _httpClient.GetFromJsonAsync<List<Building>>("Buildings"); // Работает, если GET /api/Buildings возвращает список
        return result;
    }

    public async Task Save(Building building)
    {
        if (building.Id == 0)
        {
            await _httpClient.PostAsJsonAsync("Buildings", building); // POST /api/Buildings
        }
        else
        {
            await _httpClient.PutAsJsonAsync($"Buildings/{building.Id}", building); // PUT /api/Buildings/{id}
        }
    }

    public async Task Delete(int id)
    {
        await _httpClient.DeleteAsync($"Buildings/{id}"); // DELETE /api/Buildings/{id}
    }

    public async Task<Result<Building>> Get(int id)
    {
        var result = new Result<Building>();
        try
        {
            result.Value = await _httpClient.GetFromJsonAsync<Building>($"Buildings/ {id}"); // GET /api/Buildings/{id}
        }
        catch (Exception ex)
        {
            result.Error = ex.Message;
        }
        return result;
    }

    public async Task<IList<BuildingPanels>> ListBuildingPanels()
    {
        var result = await _httpClient.GetFromJsonAsync<List<BuildingPanels>>("BuildingPanels"); // Работает, если GET /api/Buildings возвращает список
        return result;
    }

    public async Task SaveBuildingPanel(BuildingPanels panels)
    {
        if (panels.Id == 0)
        {
            await _httpClient.PostAsJsonAsync("BuildingPanels", panels); // POST /api/Buildings
        }
        else
        {
            await _httpClient.PutAsJsonAsync($"BuildingPanels/{panels.Id}", panels); // PUT /api/Buildings/{id}
        }
    }
    public async Task DeleteBuildingPanel(int id)
    {
        await _httpClient.DeleteAsync($"BuildingPanels/{id}"); // DELETE /api/Buildings/{id}
    }
    public void Dispose()
    {
        _httpClient.Dispose();
    }
}
