using BethanysPieShop.Models;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers
{
    public class ShoppingCartController : Controller
    {
        private IShoppingCart _shoppingCart;
        private IPieRepository _pieRepository;

        public ShoppingCartController(IShoppingCart cart, IPieRepository repo)
        {
            _shoppingCart = cart;
            _pieRepository = repo;
        }

        public IActionResult Index()
        {
            var shoppingCartViewModel = new ShoppingCartViewModel(
                _shoppingCart.GetShoppingCartItems(),
                _shoppingCart.GetShoppingCartTotal());

            return View(shoppingCartViewModel);
        }

        public IActionResult AddToShoppingCart(int pieId)
        {
            Pie? selectedPie = _pieRepository.GetPieById(pieId);

            if (selectedPie is not null)
            {
                _shoppingCart.AddToCart(selectedPie);
            }
            return RedirectToAction(nameof(Index));
        }

        public RedirectToActionResult RemoveFromShoppingCart(int pieId)
        {
            Pie? selectedPie = _pieRepository.GetPieById(pieId);

            if (selectedPie != null)
            {
                _shoppingCart.RemoveFromCart(selectedPie);
            }
            return RedirectToAction(nameof(Index));
        }
    }
}
