using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using NuGet.Protocol.Core.Types;
using ReservationApiCRUD.Models;
using System.Collections;

namespace ReservationApiCRUD.Controllers
{
    [Authorize]
    [ApiController]
    [Route("[controller]")]
    public class ReservationController : Controller
    {
        private readonly IRepository _repository;

        private readonly JwtService _jwtService;

        public ReservationController(IRepository repository,JwtService jwtService)
        {
            _repository = repository;
            _jwtService = jwtService;
        }

        [AllowAnonymous]
        [HttpGet("Login")]
        public IActionResult ValidLogin()
        {
           
            var accessToken =  _jwtService.GenerateJSONWebToken();
         
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                IsEssential = true,
                Secure = false,
                SameSite = SameSiteMode.None,
                Domain = "localhost", //using https://localhost:44340/ here doesn't work
                Expires = DateTime.UtcNow.AddDays(1)

            };
            HttpContext.Response.Cookies.Append("jwtcookie", accessToken, cookieOptions);
           

            return Ok(new
            {
                token = accessToken
            });


        }



 [HttpPost]
    public async Task<IActionResult> AddReservation( Reservation reservation)
    {
        if (reservation == null)
        {
            return BadRequest();
        }

        var createdReservation = await _repository.AddReservationAsync(reservation);
            return Ok(createdReservation);
    }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            return Ok (new { content =  await _repository.GetAll()});
        }

    [HttpGet("{id}")]
    public async Task<IActionResult> GetReservationById(int id)
    {
        var reservation = await _repository.GetReservationByIdAsync(id);
        if (reservation == null)
        {
            return NotFound();
        }

        return Ok(reservation);
    }
        [HttpDelete("{id}")]

        public async Task<IActionResult> Delete(int id) => await _repository.DeleteReservation(id) ? Ok() : NotFound();


        [HttpPut]

        public async Task<ActionResult<Reservation>> UpdateReservation(Reservation updatedReservation)
        {
            return await _repository.UpdateReservation(updatedReservation);
        }
    }
}
