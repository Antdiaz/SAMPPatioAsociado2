using System;
using System.Linq;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace SAMPPatioAsociado.ViewModels
{
    class DiccionarioViewModel
    {
        public Dictionary<int, string> Valores = new Dictionary<int, string>();
        public List<KeyValuePair<int, string>> PickerItemList
        {
            get => Valores.ToList();
        }

        private KeyValuePair<int, string> _selectedItem;
        public KeyValuePair<int, string> SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }
    }

    class DiccionarioViewModelTexto
    {
        public Dictionary<string, string> Valores = new Dictionary<string, string>();
        public List<KeyValuePair<string, string>> PickerItemList
        {
            get => Valores.ToList();
        }

        private KeyValuePair<string, string> _selectedItem;
        public KeyValuePair<string, string> SelectedItem
        {
            get => _selectedItem;
            set => _selectedItem = value;
        }
    }
}
