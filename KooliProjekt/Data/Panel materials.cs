namespace KooliProjekt.Data
{
    public class PanelMaterial
    {
        public int Id { get; set; }
        public Decimal Amount { get; set; }

        public Material Material { get; set; }
        public int MaterialId { get; set; }

        public Panel Panel { get; set; }
        public int PanelId { get; set; }

        public decimal UnitPrice { get; set; }

        public decimal TotalPrice { get; set; }
    }
}

