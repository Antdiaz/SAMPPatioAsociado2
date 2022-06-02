using SAMPPatioAsociado.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;
using Xamarin.Forms;

namespace SAMPPatioAsociado.ViewModels
{
    public class ListaViewModel
    {
        public List<MyListModel> MaterialList { get; set; }

        public ListaViewModel()
        {
            MaterialList = new List<MyListModel>();
           MaterialList.Add(new MyListModel { Id = Guid.NewGuid().ToString(), NombreCorto = "PI", NombreLargo = "Paca de Primera" });
        }

    
    }
}
