
namespace TrainsAPI.Models
{
    public class Train
    {
        public int ID { get; set; }
        public string? TrainName { get; set; } // Tren Adı
        public List<Wagon> Wagons { get; set; }
    }
}
