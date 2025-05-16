namespace KooliProjekt.BlazorApp.Api
{
    public class BuildingPanels
    {
        public int Id { get; set; }
        public Decimal Amount { get; set; }

        public int? BuildingId { get; set; }
        public int? PanelId { get; set; }
        public string Title { get; set; }
    }
}