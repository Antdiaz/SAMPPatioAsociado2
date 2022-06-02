using SAMPPatioAsociado.ViewModels;
using SAMPPatioAsociado.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using SAMPPatioAsociado.Models;

namespace SAMPPatioAsociado
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            VariablesGlobales.EntidadTrabajo.EsUsrCorrecto = "False";
        }
        private string esdisponible;
        public string EsDisponible { 
            get
            { return esdisponible; }
            set { esdisponible = value; }
        }
    }
}
