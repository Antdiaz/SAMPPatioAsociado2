using SAMPPatioAsociado.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace SAMPPatioAsociado.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}