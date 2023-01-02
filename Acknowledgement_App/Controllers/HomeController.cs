using Acknowledgement_App.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace Acknowledgement_App.Controllers
{
    public class HomeController : Controller
    {
        private readonly DbAckContext _dbAckContext;
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger, DbAckContext dbAckContext)
        {
            _logger = logger;
            _dbAckContext = dbAckContext;
        }

        public IActionResult AckForm()
        {
            return View();
        }


        public async Task<IActionResult> AckSubmit(Ack formData)
        {
            if (formData == null)
            {
                return RedirectToAction("AckForm");
            }
            _dbAckContext.Acks.Add(formData);
            await _dbAckContext.SaveChangesAsync();
            return View("Index", formData);
        }

        public IActionResult GetReport()
        {
            var data = _dbAckContext.Acks.ToList();
            return View(data);
        }

        public IActionResult Index()
        {
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