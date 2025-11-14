namespace Esame;

public partial class ProductDetailPage : ContentPage
{
    private Product _product;

    public ProductDetailPage(Product product)
    {
        InitializeComponent();
        _product = product;
        BindingContext = product;
    }

    private async void OnAddToCartClicked(object sender, EventArgs e)
    {
        // Salva nel carrello
        CartService.AddToCart(_product);

        await DisplayAlert("Carrello", "Prodotto aggiunto al carrello!", "OK");

        
        await Navigation.PopAsync();
    }
}
