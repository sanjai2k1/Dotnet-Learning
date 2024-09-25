using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using NuGet.Common;
using ReservationApiCRUD.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace ReservationApiCRUD.Controllers
{
    
    [ApiController]
    [Route("[controller]")]

    public class LoginController : ControllerBase
    {
        //[HttpPost]
        //public IActionResult Index(UserModel user)
        //{
        //    if (user.Username != "secret" ||user.Password != "secret")
        //    {
        //        return Unauthorized();
        //    }

        //    var accessToken = JwtService.GenerateJSONWebToken();
        //    var cookieOptions = new CookieOptions
        //    {
        //        HttpOnly = true,
        //        Expires = DateTime.Now.AddHours(3)
        //    };
        //    Response.Cookies.Append("jwtcookie", token, cookieOptions);
        //    SetJWTCookie(accessToken);

        //    return Ok(new { Token = accessToken });
        //}
       

        //[HttpGet("GetAll")]
        //public async Task<IActionResult> GetAll()
        //{
        //    Console.WriteLine("Hii");
        //    var jwt = Request.Cookies["jwtcookie"];

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

        //        using (var response = await httpClient.GetAsync("http://localhost:5279/Reservation"))
        //        {
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                Console.WriteLine(apiResponse);
        //                return Ok(apiResponse);
        //            }
        //            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        //            {
        //                return Unauthorized();
        //            }
        //        }
        //    }

        //    return Ok();
        //}

        //[HttpGet("GetById/{id}")]
        //public async Task<IActionResult> GetById(int id)
        //{

        //    var jwt = Request.Cookies["jwtcookie"];

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);
               
        //        using (var response = await httpClient.GetAsync("http://localhost:5279/Reservation/"+id))
        //        {
        //            Console.WriteLine(response);
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                Console.WriteLine(apiResponse);
        //                return Ok(apiResponse);

        //            }
        //            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        //            {
        //                return Unauthorized();
        //            }
        //        }
        //    }

        //    return Ok();
        //}



        //[HttpPost("Add")]
        //public async Task<IActionResult> Add([FromBody] Reservation reservation)
        //{
        //    var jwt = Request.Cookies["jwtcookie"];
        //    if (string.IsNullOrEmpty(jwt))
        //    {
        //        return Unauthorized("JWT token is missing.");
        //    }

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

        //        var jsonContent = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");

        //        using (var response = await httpClient.PostAsync("http://localhost:5279/Reservation", jsonContent))
        //        {
                   
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                return Ok(apiResponse);
        //            }
        //            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        //            {
        //                return Unauthorized();
        //            }
        //            else
        //            {
        //                return StatusCode((int)response.StatusCode, "An error occurred while adding the reservation.");
        //            }
        //        }
        //    }
        //}

        //[HttpDelete("Delete/{id}")]
        //public async Task<IActionResult> Delete(int id)
        //{
        //    Console.WriteLine("from delete");

        //    var jwt = Request.Cookies["jwtcookie"];

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);
                
        //        using (var response = await httpClient.DeleteAsync("http://localhost:5279/Reservation/"+id))
        //        {
        //            Console.WriteLine(response);
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                Console.WriteLine(apiResponse);
        //                return Ok(apiResponse);

        //            }
        //            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        //            {
        //                return Unauthorized();
        //            }
        //        }
        //    }

        //    return Ok();
        //}

        //[HttpPost("Update")]
        //public async Task<IActionResult> Update([FromBody] Reservation reservation)
        //{

        //    var jwt = Request.Cookies["jwtcookie"];
        //    if (string.IsNullOrEmpty(jwt))
        //    {
        //        return Unauthorized("JWT token is missing.");
        //    }

        //    using (var httpClient = new HttpClient())
        //    {
        //        httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

        //        var jsonContent = new StringContent(JsonConvert.SerializeObject(reservation), Encoding.UTF8, "application/json");

        //        using (var response = await httpClient.PutAsync("http://localhost:5279/Reservation", jsonContent))
        //        {
        //            Console.WriteLine(response);
        //            if (response.StatusCode == System.Net.HttpStatusCode.OK)
        //            {
        //                string apiResponse = await response.Content.ReadAsStringAsync();
        //                return Ok(apiResponse);
        //            }
        //            else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
        //            {
        //                return Unauthorized();
        //            }
        //            else
        //            {
        //                return StatusCode((int)response.StatusCode, "An error occurred while adding the reservation.");
        //            }
        //        }
        //    }
            
        //}

    }
}
