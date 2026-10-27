using System.Diagnostics;
using Imobiliaria_EF.Data;
using Imobiliaria_EF.Models;
using Microsoft.AspNetCore.Mvc;

namespace Imobiliaria_EF.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ImobiliariaContext _context;

        public HomeController(ILogger<HomeController> logger, ImobiliariaContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var imoveis = _context.Imoveis.ToList(); 
            return View(imoveis);                    
        }

        public IActionResult Inquilino()
        {
            var inquilino = _context.Inquilinos.ToList();
            return View(inquilino);
        }

        public IActionResult InquilinoImoveis()
        {
            var inquilinoImoveis = _context.InquilinoImoveis.ToList();
            return View(inquilinoImoveis);
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
