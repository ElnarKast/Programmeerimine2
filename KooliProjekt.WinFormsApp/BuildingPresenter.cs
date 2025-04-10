using KooliProjekt.WinFormsApp.Api;

namespace KooliProjekt.WinFormsApp
{
    public class BuildingPresenter
    {
        private readonly IApiClient _apiClient;
        private readonly IBuildingView _buildingView;
        private Form1 form;

        public BuildingPresenter(IBuildingView buildingView, IApiClient apiClient)
        {
            _apiClient = apiClient;
            _buildingView = buildingView;

            buildingView.Presenter = this;
        }

        public BuildingPresenter(Form1 form, ApiClient apiClient)
        {
            this.form = form;
            _apiClient = apiClient;
        }

        public void UpdateView(Building list)
        {
            if (list == null)
            {
                _buildingView.Title = string.Empty;
                _buildingView.Id = 0;
            }
            else
            {
                _buildingView.Id = list.Id;
                _buildingView.Title = list.Title;
            }
        }

        public async Task Load()
        {
            var buildings = await _apiClient.List();

            _buildingView.Building = buildings.Value;
        }
    }
}