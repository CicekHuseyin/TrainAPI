using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TrainsAPI.Data;
using TrainsAPI.Models;

namespace TrainsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TrensController : ControllerBase
    {
        private readonly APIDbContext dbContext;

        public TrensController(APIDbContext dbContext)
        {
            this.dbContext = dbContext;
        }
        [HttpPost]
        public IActionResult PostReservation(AddRezervation rezervation)
        {
            var filledseats = rezervation.Trains.Wagons[3].WagonCapacity;
            var capasity = rezervation.Trains.Wagons[2].WagonCapacity;
            for (int i = 0; i < rezervation.Trains.Wagons.Count; i++)
            {
                if (filledseats >= capasity * 0.7)
                {
                    return BadRequest(new { error = "Kişi sayısı Vagon kapasitesinin %70 inden fazla olduğu için kayıt yapılamıyor." });
                }
                else
                {
                    return Ok(new
                    {
                        RezervasyonYapilabilir = true,
                        YerlesimAyrinti = new List<WagonSeatAssignment>()
                    });
                }
            }
            return Ok();
        }
        private List<WagonSeatAssignment> GetSeatAssignments(AddRezervation reservation)
        {
            var seatAssignments = new List<WagonSeatAssignment>();
            foreach (var wagon in reservation.Trains.Wagons)
            {
                if (wagon.WagonCapacity - wagon.FilledSeats >= reservation.ReservationPersonCount)
                {
                    seatAssignments.Add(new WagonSeatAssignment());
                }
            }
            return seatAssignments;
        }

        public class WagonSeatAssignment
        {
            public string WagonName { get; set; }
            public int PersonCount { get; set; }
        }
    }
}
