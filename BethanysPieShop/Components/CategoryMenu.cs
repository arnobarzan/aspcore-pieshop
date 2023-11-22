using BethanysPieShop.Models;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components
{
    public class CategoryMenu : ViewComponent
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryMenu(ICategoryRepository repo)
        {
            _categoryRepository = repo;
        }

        public IViewComponentResult Invoke()
        {
            return View(_categoryRepository.AllCategories.OrderBy(c => c.CategoryName));
        }
    }
}
