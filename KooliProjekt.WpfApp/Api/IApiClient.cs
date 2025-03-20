namespace KooliProjekt.WpfApp.Api
{
    public interface IApiClient
    {
        Task<IList<Building>> List();
        Task Save(Building list);
        Task Delete(int id);
    }
}