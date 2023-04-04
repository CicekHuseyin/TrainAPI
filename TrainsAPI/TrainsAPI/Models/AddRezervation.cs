
namespace TrainsAPI.Models
{
    public class AddRezervation
    {
        public Train? Trains { get; set; }
        //public Wagon Wagons{ get; set; }
        public int ReservationPersonCount { get; set; }
        public bool CanPeopleBeSeatedInDifferentWagons { get; set; }

    }
}
