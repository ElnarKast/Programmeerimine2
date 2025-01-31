namespace KooliProjekt.Data
{
    public class BuildingPanels
    {
        public int Id { get; set; }
        public Decimal Amount { get; set; }

        public Building Building { get; set; }
        public int BuildingId { get; set; }

        public Panel Panel { get; set; }
        public int PanelId { get; set; }
        public string Title { get; set; }
    }
}
