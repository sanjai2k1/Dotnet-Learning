using Microsoft.AspNetCore.Mvc;
using NuGet.Common;
using ReservationApiCRUD.Models;

namespace ReservationApiCRUD.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Login()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Login(string username, string password)
        {
            UserModel model = new UserModel { Username = username, Password = password };
            using (var httpClient = new HttpClient())
            {
                var jsonContent = JsonContent.Create(model);
                using (var response = await httpClient.PostAsync("http://localhost:5279/Reservation/Login", jsonContent))
                {
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(apiResponse);
                        return View("Index");
                    }
                    else if (response.StatusCode == System.Net.HttpStatusCode.Unauthorized)
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        return View("Login", (object)errorResponse);
                    }
                }


            }
            return View("Login");
        }



        public IActionResult Index()
        {
            return View();
        }

    }
}
