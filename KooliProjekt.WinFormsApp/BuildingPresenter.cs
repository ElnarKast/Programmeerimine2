using KooliProjekt.WinFormsApp.Api;

namespace KooliProjekt.WinFormsApp
{
    public class BuildingPresenter
    {
        private readonly IApiClient _apiClient;
        private readonly IBuildingView _BuildingView;
        private Form1 form;

        public BuildingPresenter(IBuildingView BuildingView, IApiClient apiClient)
        {
            _apiClient = apiClient;
            _BuildingView = BuildingView;

            BuildingView.Presenter = this;
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
                _BuildingView.Title = string.Empty;
                _BuildingView.Id = 0;
            }
            else
            {
                _BuildingView.Id = list.Id;
                _BuildingView.Title = list.Title;
            }
        }

        public async Task Delete()
        {
            if (_BuildingView.SelectedItem == null)
            {
                MessageBox.Show("Palun vali kategooria, mida kustutada!", "Hoiatus", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var Building = _BuildingView.SelectedItem;

            var result = MessageBox.Show($"Kas oled kindel, et soovid kategooria '{Building.Title}' kustutada?",
                                        "Kustutamise kinnitus", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (result == DialogResult.Yes)
            {
                var deleteResult = await _apiClient.Delete(Building.Id);
                if (deleteResult.IsSuccess)
                {
                    MessageBox.Show("Kategooria kustutatud!", "Teade", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    // Lae andmed uuesti
                    await Load();
                }
                else
                {
                    MessageBox.Show($"Kustutamine ebaõnnestus: {deleteResult.Error}",
                                    "Viga", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        public async Task Save()
        {

        }

        public async Task Load()
        {
            var Building = await _apiClient.List();

            _BuildingView.Building = Building.Value;
        }
    }
}