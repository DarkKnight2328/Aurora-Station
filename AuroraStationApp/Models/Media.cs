namespace AuroraStationApp.Models
{
    public class Media
    {
        public int Id { get; set; }
        public string Tipo { get; set; } // "Video" o "Foto"
        public string Url { get; set; }
        public string Descrizione { get; set; }
        public DateTime DataCaricamento { get; set; }
    }
}
