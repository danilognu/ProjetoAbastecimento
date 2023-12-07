using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ProjetoBitzen.Models;
using ProjetoBitzen.Repository;

namespace ProjetoBitzen.Controllers
{
    public class LoginController : Controller
    {
        private IUsuarioRepository _iUsuarioRepository;

        public LoginController(IUsuarioRepository iUsuarioRepository)
        {
            _iUsuarioRepository = iUsuarioRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Logar(Usuario usuario)
        {
            var result = await _iUsuarioRepository.ObterUsuario(usuario);
            if (result.Id > 0)
            {
                HttpContext.Session.SetString("login", result.Login);
                HttpContext.Session.SetString("name", result.Nome);
                HttpContext.Session.SetString("id", result.Id.ToString());
            }

            return View(result);
        }



    }
}
