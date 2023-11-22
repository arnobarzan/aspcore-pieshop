using BethanysPieShop.Models;

namespace BethanysPieShop
{
    public interface IShoppingCart
    {
        void AddToCart(Pie pie);
        int RemoveFromCart(Pie pie);
        List<ShoppingCartItem> GetShoppingCartItems();
        void ClearCart();
        decimal GetShoppingCartTotal();
    }
}