using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class PieController : Controller
    {
        private readonly IPieRepository _pieRepository;
        private readonly ICategoryRepository _categoryRepository;

        public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
        {
            _pieRepository = pieRepository;
            _categoryRepository = categoryRepository;
        }

        public IActionResult List(string category)
        {
            //ViewBag.CurrentCategory = "Cheese cakes";

            //return View(_pieRepository.AllPies);
            PieListViewModel piesListViewModel;
            if (category == null)
            {
                category = "All Pies";
                piesListViewModel = new PieListViewModel(_pieRepository.AllPies, category);
            } else
            {
                var pies = _pieRepository.AllPies.Where(p => p.Category.CategoryName == category);
                piesListViewModel = new PieListViewModel(pies, category);
            }

            return View(piesListViewModel);
        }

        public IActionResult Details(int id)
        {
            var pie = _pieRepository.GetPieById(id);
            if (pie == null)
                return NotFound();

            return View(pie);
        }

        public IActionResult CategoryList(int categoryId, int numberToShow = 10) {

            ViewBag.NumberToShow = numberToShow;

            var filteredPies = _pieRepository.AllPies.Where(p => p.CategoryId == categoryId).Take(numberToShow).ToList();
    
            return View(filteredPies);
        }
    }
}
