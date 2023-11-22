using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class HomeController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ISession? _session;

        public HomeController(IPieRepository pieRepository, IServiceProvider provider)
        {
            _pieRepository = pieRepository;
            _session = provider.GetRequiredService<IHttpContextAccessor>().HttpContext?.Session;
        }

        public ViewResult Index()
        {
            var piesOfTheWeek = _pieRepository.PiesOfTheWeek;

            var homeViewModel = new HomeViewModel(piesOfTheWeek);

            return View(homeViewModel);
        }
    }
}
