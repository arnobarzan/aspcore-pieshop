using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components
{
    public class ShoppingCartSummary : ViewComponent
    {
        private readonly IShoppingCart _shoppingCart;

        public ShoppingCartSummary(IShoppingCart cart)
        {
            _shoppingCart = cart;
        }

        public IViewComponentResult Invoke()
        {
            var viewModel = new ShoppingCartViewModel(
                _shoppingCart.GetShoppingCartItems(),
                _shoppingCart.GetShoppingCartTotal()
                );
            return View(viewModel);
        }
    }
}
