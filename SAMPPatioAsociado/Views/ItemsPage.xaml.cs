using SAMPPatioAsociado.Models;
using SAMPPatioAsociado.ViewModels;
using SAMPPatioAsociado.Views;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Newtonsoft.Json;

namespace SAMPPatioAsociado.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ItemsPage : ContentPage
    {
        SAMPPatioAsociado.ViewModels.DiccionarioViewModel ProveedoresListado;
        int ClaProveedorSeleccionado;
        string NombreProveedorSeleccionado;
        public ItemsPage()
        {
            InitializeComponent();

            BindingContext = new ListaViewModel();

        }

        //protected override void ItemsPage()
        //{
        //    base.OnAppearing();

        //    CargarMateriales();
        //}
        protected override void OnAppearing()
        {
            ProveedoresListado = new SAMPPatioAsociado.ViewModels.DiccionarioViewModel();
            base.OnAppearing();
            CargarProveedores();
            CargarMateriales();
        }
        async void CargarProveedores()
        {
            try
            {

                if (VariablesGlobales.EntidadTrabajo != null)
                {

                    // string respuesta ="";//= await VariablesGlobales.Consumo.ConsumeServicioExecSwitch(
                    //ServiciosJson.ServicioGenClasif, new ConsultaGenerica
                    //{
                    //    tipoEstructura = 0,
                    //    parameters =
                    //"{\"ClaUbicacion\":" + VariablesGlobales.Autenticacion.ClaUbicacion +
                    //",\"Token\":\"" + VariablesGlobales.Autenticacion.token + "\",\"ClaServicioJson\":" + ServiciosJson.ConsultarMaterailesdelProv +
                    //",\"Parametros\":" +
                    //"\"@pnClaUbicacion=" + VariablesGlobales.Autenticacion.ClaUbicacion
                    //+ "<@@>@pnIdListaPrecio=" + VariablesGlobales.EntidadTrabajo.MiPlaca.IdListaPrecio
                    //+ idordencompra
                    //+ clatipoordencompra
                    //+ idacuerdo
                    //+ idpedidoimportacion
                    //+ "<@@>@pnIdBoleta=" + VariablesGlobales.EntidadTrabajo.MiPlaca.IdBoleta
                    //+ "\"}"
                    //}, ServiciosJson.ConsultarMaterailesdelProv);

                    string respuesta = await VariablesGlobales.Consumo.ConsumeServicioExecSwitch(ServiciosJson.ServicioProveedor,
                new ConsultaGenerica
                {
                    tipoEstructura = 1,
                    parameters = "{\"ClaUbiAsociado\":\"" + 26 + "\"}"
                });


                    RespuestaProveedores respuestaGenerica = JsonConvert.DeserializeObject<RespuestaProveedores>
                    (respuesta, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });


                    foreach (Proveedor col in respuestaGenerica.Result0)
                    {
                        ProveedoresListado.Valores.Add(col.ClaProveedor, col.NombreProveedor);

                    }

                    Proveedor.BindingContext = ProveedoresListado;//.UbicacionID1;
                    Proveedor.ItemsSource = ProveedoresListado.PickerItemList;
                    Proveedor.SelectedItem = ProveedoresListado.SelectedItem;
                }

                if (Proveedor.Items.Count == 1)// si solo es un valor
                {
                    //selecciono solo un valor
                    Proveedor.SelectedIndex = 0;
                }

                int i = 0;
                while (i < (Proveedor.Items.Count()) && i != 0)
                {

                    if (Proveedor.Items[i].ToString().Trim() == NombreProveedorSeleccionado.ToString().Trim())//si es igual al que se seleccionó en el inicio
                    {
                        Proveedor.SelectedIndex = i;
                        break;
                    }
                    i++;
                }
                i = 0;

            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", ex.Message.ToString(), "OK");
            }



        }

        async void CargarMateriales()
        {
            try
            {

                if (VariablesGlobales.EntidadTrabajo != null)
                {

                    // string respuesta ="";//= await VariablesGlobales.Consumo.ConsumeServicioExecSwitch(
                    //ServiciosJson.ServicioGenClasif, new ConsultaGenerica
                    //{
                    //    tipoEstructura = 0,
                    //    parameters =
                    //"{\"ClaUbicacion\":" + VariablesGlobales.Autenticacion.ClaUbicacion +
                    //",\"Token\":\"" + VariablesGlobales.Autenticacion.token + "\",\"ClaServicioJson\":" + ServiciosJson.ConsultarMaterailesdelProv +
                    //",\"Parametros\":" +
                    //"\"@pnClaUbicacion=" + VariablesGlobales.Autenticacion.ClaUbicacion
                    //+ "<@@>@pnIdListaPrecio=" + VariablesGlobales.EntidadTrabajo.MiPlaca.IdListaPrecio
                    //+ idordencompra
                    //+ clatipoordencompra
                    //+ idacuerdo
                    //+ idpedidoimportacion
                    //+ "<@@>@pnIdBoleta=" + VariablesGlobales.EntidadTrabajo.MiPlaca.IdBoleta
                    //+ "\"}"
                    //}, ServiciosJson.ConsultarMaterailesdelProv);

                    string respuesta = await VariablesGlobales.Consumo.ConsumeServicioExecSwitch(ServiciosJson.ServicioMateriales,
                new ConsultaGenerica
                {
                    tipoEstructura = 1,
                    parameters = "{\"ClaUbiAsociado\":\"" + 26 + "\"" +
                   ",\"ClaProveedor\":\"" + 1 //Valor
                   + "\"}"
                });


                    RespuestaMateriales respuestaGenerica = JsonConvert.DeserializeObject<RespuestaMateriales>
                    (respuesta, new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore });



                    int row = 0;
                    int column = 0;
                    int maxcol = 2;


                    foreach (Material col in respuestaGenerica.Result0)
                    {

                        Button button = new Button
                        {
                            Text = col.NomCorto,//.Replace("-", "&#x0a;"),
                            Style = (Style)Application.Current.Resources["OrangeSmall"]

                        };
                        // button.Clicked += async (sender, args) => await Navigation.PushAsync(new MaterialPorcentaje(col.ClaArticuloCompra, col.NomArticuloCompra, 1, ClaArticuloPrereg, NomArticuloPrereg)); }


                        GridOpciones.Children.Add(button, column, 0);

                        column++;




                    }


                }



            }
            catch (Exception ex)
            {

                await DisplayAlert("Alerta", ex.Message.ToString(), "OK");
            }



        }
        private void Proveedor_SelectedIndexChanged(object sender, EventArgs e)
        {
            NombreProveedorSeleccionado = ProveedoresListado.SelectedItem.Value;
        }



    }
}