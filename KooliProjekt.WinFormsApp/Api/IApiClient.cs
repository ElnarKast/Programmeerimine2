namespace KooliProjekt.WinFormsApp.Api
{
    public interface IApiClient
    {
        Task<Result> Save(Building building);
        Task<Result> Delete(int id);
        Task<Result<List<Building>>> List();
    }
}