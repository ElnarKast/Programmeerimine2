using KooliProjekt.WinFormsApp;
using KooliProjekt.WinFormsApp.Api;

namespace KooliProjekt.WinFormsApp
{
    public interface IBuildingView
    {
        IList <Building> Building { get; set; }
        Building SelectedItem { get; set; }
        string Title { get; set; }
        int Id { get; set; }
        BuildingPresenter Presenter { get; set; }
    }
}
