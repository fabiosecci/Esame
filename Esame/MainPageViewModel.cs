using System.Collections.ObjectModel;
using System.Windows.Input;

namespace Esame
{
    public class MainPageViewModel
    {
        public ObservableCollection<Product> Products { get; set; } = new ObservableCollection<Product>();

        private readonly RestService _restService;

        public ICommand OpenDetailsCommand { get; }

        public MainPageViewModel()
        {
            _restService = new RestService();
            OpenDetailsCommand = new Command<Product>(OpenDetails);
            LoadProducts();
        }

        private async void LoadProducts()
        {
            var list = await _restService.GetProductsAsync();
            Products.Clear();

            foreach (var p in list)
                Products.Add(p);
        }

        private async void OpenDetails(Product product)
        {
            if (product == null)
                return;

            await Shell.Current.Navigation.PushAsync(new ProductDetailPage(product));
        }
    }
}
