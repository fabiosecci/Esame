using System.Text.Json;

namespace Esame
{
    public static class CartService
    {
        private const string CartKey = "cart_items";

        public static List<Product> GetCart()
        {
            if (!Preferences.ContainsKey(CartKey))
                return new List<Product>();

            var json = Preferences.Get(CartKey, string.Empty);
            return JsonSerializer.Deserialize<List<Product>>(json) ?? new List<Product>();
        }

        public static void AddToCart(Product product)
        {
            var cart = GetCart();
            cart.Add(product);

            var json = JsonSerializer.Serialize(cart);
            Preferences.Set(CartKey, json);
        }
    }
}
