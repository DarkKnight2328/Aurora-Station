namespace AuroraStationApp.Models
{
    public class Partita
    {
        public int Id { get; set; }
        public DateTime DataOra { get; set; }
        public string Avversario { get; set; }
        public string Luogo { get; set; }
        public int GoalFatti { get; set; }
        public int GoalSubiti { get; set; }
        public bool PartitaConclusa { get; set; }
    }
}
