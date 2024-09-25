using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SecurityDemo.Models;

namespace SecurityDemo.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        [HttpGet]

        public IEnumerable<Reservation> Get() => CreateDummyReservations();

        public List<Reservation> CreateDummyReservations()
        {
            List<Reservation> rlist = new List<Reservation> {
            new Reservation {Id =1 ,Name ="Parag",StartLocation = "London",EndLocation ="Delhi",},
            new Reservation {Id =2 ,Name ="Parachi",StartLocation = "Mumbai",EndLocation ="Chennai",},
            new Reservation {Id =3 ,Name ="Anand",StartLocation = "Chennai",EndLocation ="Pune",},
            new Reservation {Id =4 ,Name ="Swtha",StartLocation = "Delhi",EndLocation ="London",}




            }; 
            return rlist;
        }
    }
}
