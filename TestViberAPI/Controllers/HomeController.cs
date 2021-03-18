using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Threading.Tasks;
using TestViberAPI.Models;
using IRepository;

namespace TestViberAPI.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private IServiceViber _serviceProvider;

        public HomeController(ILogger<HomeController> logger, IServiceViber provider)
        {
            _logger = logger;
            _serviceProvider = provider;
        }

        public async Task<IActionResult> Index()
        {
            IEnumerable<UserDisplay> viewResult;
            using (var s = new StreamReader(Request.Body))
            {
                var us = await s.ReadToEndAsync();
                if (!string.IsNullOrEmpty(us))
                    await _serviceProvider.AddUser(us);

                var result = await _serviceProvider.GetUsers();
                viewResult = result.Select(i => new UserDisplay
                {
                    Id = i.Id,
                    IdViber = i.IdViber,
                    Name = i.Name,
                });
            };
            return View(viewResult);
        }

        public async Task<IActionResult> UpdateUser(int id)
        {
            await _serviceProvider.UpdateUser(id);
            var result = await _serviceProvider.GetUser(id);
            var viewResult = new UserDisplay
            {
                IdViber = result.IdViber,
                Name = result.Name,
                Language = result.Language,
                Country = result.Country,
                DeviceType = result.DeviceType,
            };

            return View(viewResult);
        }
     

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
