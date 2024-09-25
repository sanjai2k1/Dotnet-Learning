using jwtfronttest.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Net.Http.Headers;

namespace jwtfronttest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
     
        public async Task<IActionResult> Index()
        {
            var handler = new HttpClientHandler
            {
                UseCookies = true,
                Credentials = System.Net.CredentialCache.DefaultCredentials // Use default credentials
            };
            using (var httpClient = new HttpClient(handler))
            {
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                using (var response = await httpClient.GetAsync("https://localhost:7227/auth"))
                {
                    Console.WriteLine(response);
                    if (response.StatusCode == System.Net.HttpStatusCode.OK)
                    {
                        string apiResponse = await response.Content.ReadAsStringAsync();






                        //var reservation = JsonConvert.DeserializeObject<List<Reservation>>(apiResponse);

                        Console.WriteLine(apiResponse);
                    }
                    else
                    {
                        string errorResponse = await response.Content.ReadAsStringAsync();
                        Console.WriteLine(errorResponse);
                    }
                }
            }
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
