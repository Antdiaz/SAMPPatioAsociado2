using SAMPPatioAsociado.ViewModels;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SAMPPatioAsociado.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class LoginPage : ContentPage
    {
        public LoginPage()
        {
            var vm = new LoginViewModel();
            BindingContext = vm;
            vm.DisplayInvalidLoginPrompt += () => DisplayAlert("Error", "Usuario/Contraseña invalido", "OK");
            vm.DisplayMensaje += (string mensaje) => { DisplayAlert("Alerta", mensaje, "OK"); };
            vm.Loggeado += () => Shell.Current.GoToAsync("//main");
            InitializeComponent();

            Email.Completed += (sender, e) =>
            {
                Password.Focus();
            };

            Password.Completed += (sender, e) =>
            {
                vm.SubmitCommand.Execute(null);
            };
        }
    }
}