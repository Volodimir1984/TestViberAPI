using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using IRepository;


namespace TestViberAPI.Controllers
{
    public class RegisterController: Controller
    {
        private IServiceViber _repository;

        public RegisterController(IServiceViber repository)
        {
            _repository = repository;
        }

        public async Task<IActionResult> Register()
        {
            await _repository.SetWebHook();

            if (_repository.IsRegister())
                ViewData["Register"] = "You have successfully registered web-hook";
            else
                ViewData["Register"] = "Failed to register web-hook";

            return View();
        }

        public async Task<IActionResult> RemoveWebHook()
        {
            await _repository.RemoveWebHook();

            if (!_repository.IsRegister())
                ViewData["Register"] = "You have successfully removed web-hook";
            else
                ViewData["Register"] = "Failed to register removed web-hook";

            return View();
        }
    }
}
