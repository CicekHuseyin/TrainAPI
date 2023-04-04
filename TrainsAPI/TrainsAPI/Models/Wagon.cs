namespace TrainsAPI.Models
{
    public class Wagon
    {
        public int ID { get; set; }
        public string? WagonName { get; set; } //Vagon Adı
        public int WagonCapacity { get; set; } //VagonKapasite
        public int FilledSeats { get; set; } //DoluKoltukSayisi
    }
}
