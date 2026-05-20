using ConferenceMVC.Web.Models;
using ConferenceMVC.Web.Services;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace ConferenceMVC.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly IActiveEventService _activeEventService;


        public HomeController(IActiveEventService activeEventService)
        {
            _activeEventService = activeEventService;
        }

        public async Task<IActionResult> Index()
        {

            var activeId = await _activeEventService.GetActiveConferenceIdAsync();

            if (activeId != null)
            {
 
                return RedirectToAction("Details", "Conferences", new { id = activeId });
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
