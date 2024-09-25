using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel;
using Microsoft.IdentityModel.Tokens;
using Newtonsoft.Json;
using SecurityDemo.Models;
using System.IdentityModel.Tokens.Jwt;
using System.Text;

namespace SecurityDemo.Controllers
{
    public class CallAPIController : Controller
    {

        public IActionResult Index(string message)
        {
            ViewBag.Message = message;
            return View();
        }

        [HttpPost]

        public IActionResult Index(string username, string password)
        {
            if((username !="secret") || (password != "secret"))
            {
                return View((object) "Login Failed");
            }
            Console.WriteLine(username + " " + password);
            var accesstoken = GenerateJSONWebToken();
            setJWTCookie(accesstoken);

            return RedirectToAction("FlightReservation");


        }

        private string GenerateJSONWebToken()
        {
            var securitykey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("MynameisJamesBond0007_MynameisJamesBond007"));
            var credentials = new SigningCredentials(securitykey, SecurityAlgorithms.HmacSha256);


            var token = new JwtSecurityToken(
                issuer: "https://www.yogihosting.com",
                audience:"dotnetclient",
                expires:DateTime.Now.AddHours(3),
                signingCredentials:credentials
                
                
                );
            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public void setJWTCookie(string token)
        {
            var cookieoptions =
                 new CookieOptions()
                 {
                     HttpOnly = true,
                     Expires = DateTime.Now.AddHours(3)
                 };
                Response.Cookies.Append("jwtcookie", token, cookieoptions);

        }





        public async Task<IActionResult> FlightReservation()
        {
            //var jwt = Request.Cookies["jwtcookie"];
            //List<Reservation> resvationList = new List<Reservation>();
            //using(var httpClient = new HttpClient())
            //{
            //    httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", "jwt");

            //    using (var response = await httpClient.GetAsync("https://localhost:7295/Reservation")) {


            //        if (response.StatusCode == System.Net.HttpStatusCode.OK)
            //        {
            //            string apiResponse = await response.Content.ReadAsStringAsync();
            //            resvationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
            //        }


            //        if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
            //        {
            //            return RedirectToAction("Index", new { message = "Please login again" });
            //        }
            //    }
            //}

            //return View(resvationList);
            var jwt = Request.Cookies["jwtcookie"];
            List<Reservation> resvationList = new List<Reservation>();
            using (var httpClient = new HttpClient())
            {
                httpClient.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", jwt);

                using (var response = await httpClient.GetAsync("https://localhost:7295/Reservation"))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        resvationList = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        return RedirectToAction("Index", new { message = "Please login again" });
                    }
                }
            }

            return View(resvationList);
        }
    }
}
