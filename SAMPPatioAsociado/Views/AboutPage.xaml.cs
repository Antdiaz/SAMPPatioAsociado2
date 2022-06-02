using System;
using System.ComponentModel;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

using SAMPPatioAsociado.Models;
namespace SAMPPatioAsociado.Views
{
    public partial class AboutPage : ContentPage
    {
        public AboutPage()
        {
            InitializeComponent();
        }
        protected override void OnAppearing()
        {
            if (VariablesGlobales.EntidadTrabajo.EsUsrCorrecto == "False")
            {
                 // Shell.Current.GoToAsync($"//{nameof(LoginPage)}");
             //   Shell.Current.GoToAsync("//LoginPage");
                Navigation.PushAsync(new LoginPage( ));

                return;
            }
            base.OnAppearing();
        }
    }
}