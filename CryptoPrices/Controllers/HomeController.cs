using CryptoPrices.Infra.Models;
using CryptoPrices.Infra.Services.Abstract;
using CryptoPrices.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace CryptoPrices.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ICryptoService _cryptoService;


        public HomeController(ILogger<HomeController> logger, ICryptoService cryptoService)
        {
            _logger = logger;
            _cryptoService = cryptoService;
        }

        public IActionResult Index(CryptoResponseModel coin)
        {
            var response = _cryptoService.GetCoinByCode(coin.Code);
            return View(response);

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