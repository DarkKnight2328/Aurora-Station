namespace AuroraStationApp.Models
{
    public class Giocatore
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string Ruolo { get; set; }
        public int NumeroMaglia { get; set; }
        public int Presenze { get; set; }
        public int Goal { get; set; }
        public int Assist { get; set; }
        public string FotoUrl { get; set; }
    }
}
