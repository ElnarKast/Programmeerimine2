namespace KooliProjekt.WinFormsApp.Api
{
    public interface IApiClient
    {
        Task<Result<List<Building>>> List();
        Task Save(Building list);
        Task Delete(int id);
    }
}