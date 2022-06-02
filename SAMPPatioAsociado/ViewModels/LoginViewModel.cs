using System;  
using System.ComponentModel;  
using System.Windows.Input;  
using Xamarin.Forms;
using SAMPPatioAsociado.Models;
using Newtonsoft.Json;

namespace SAMPPatioAsociado.ViewModels
{  
    public class LoginViewModel : INotifyPropertyChanged  
    {
        public Action Loggeado;
        public Action DisplayInvalidLoginPrompt;
        public Action<string> DisplayMensaje;

        public event PropertyChangedEventHandler PropertyChanged = delegate { };  
        private string email;  
        public string Email
        {  
            get { return email; }  
            set  
            {  
                email = value;  
                PropertyChanged(this, new PropertyChangedEventArgs("Email"));  
            }  
        }  
        private string password;
        private int esvalido=0;
        public string Password
        {  
            get { return password; }  
            set  
            {  
                password= value;  
                PropertyChanged(this, new PropertyChangedEventArgs("Password"));  
            }  
        }  
        public ICommand SubmitCommand { protected set; get; }  
        public LoginViewModel()  
        {  
            SubmitCommand = new Command(OnSubmit);  
        }
        async void   ValidarUsuario(string LoginUsr, string Contrasena) {
        
            string respuesta = await VariablesGlobales.Consumo.ConsumeServicioExecSwitch(ServiciosJson.ServicioLogin,
                  new ConsultaGenerica
                  {
                      tipoEstructura = 1,
                      parameters = "{\"LoginUsr\":\"" + LoginUsr + "\"" +
                     ",\"Contrasena\":\"" + Contrasena
                     + "\"}"
                  } );
            RespuestaUsuarioDatos respuestaGenerica = JsonConvert.DeserializeObject<RespuestaUsuarioDatos>(respuesta);

            if (respuestaGenerica.message != null && respuestaGenerica.message != "")
            { 
                DisplayMensaje(respuestaGenerica.message.ToString()); 
                return;
            }
            foreach (UsuarioDatos col in respuestaGenerica.Result0)
            {
                VariablesGlobales.Autenticacion.EsValido = col.EsValido;
                VariablesGlobales.Autenticacion.ClaUbiAsociadoUsuario = col.ClaUbiAsociadoUsuario;
                VariablesGlobales.Autenticacion.NombreUsuario = col.NombreUsuario;
                VariablesGlobales.Autenticacion.ApellidoPaterno = col.ApellidoPaterno;
                VariablesGlobales.Autenticacion.ApellidoMaterno = col.ApellidoMaterno;
                VariablesGlobales.Autenticacion.ClaUbiAsociadoDefault = col.ClaUbiAsociadoDefault;
                VariablesGlobales.Autenticacion.AppVersion = col.AppVersion;
                VariablesGlobales.Autenticacion.ClaUbiAsociado = col.ClaUbiAsociado;
                VariablesGlobales.Autenticacion.statusCode = col.statusCode;
                VariablesGlobales.Autenticacion.message = col.message;
                VariablesGlobales.Autenticacion.EsOffline = col.EsOffline;
                VariablesGlobales.Autenticacion.EsSincroniza = col.EsSincroniza; 

                break;

            }

            esvalido = VariablesGlobales.Autenticacion.EsValido;
            if (esvalido == 1)
            {
                Loggeado();
            }
            else
            {
                DisplayInvalidLoginPrompt();
            }

        }
        async void GeneraToken(string LoginUsr, string Contrasena)
        {
            string LoginUsrAux = "5542";
            string ContrasenaAux = "password";
            string respuesta = await VariablesGlobales.Consumo.ConsumeServicioporIDLogin(LoginUsrAux, ContrasenaAux);
            AuthenticateKraken autenticacion = JsonConvert.DeserializeObject<AuthenticateKraken>(respuesta);

            string errorlogueo = "";

            if (autenticacion.mensaje != null && autenticacion.mensaje.Trim() != "")
            { errorlogueo = autenticacion.mensaje.Trim(); }

            if (autenticacion.message != null && autenticacion.message.Trim() != "")
            { errorlogueo = autenticacion.message.Trim(); }

            if (errorlogueo != "")
            {
                DisplayMensaje(errorlogueo);
                return;
            }
            VariablesGlobales.Autenticacion = autenticacion;
            ValidarUsuario(LoginUsr, Contrasena);


        }
        public void OnSubmit()  
        {
            try
            {
                GeneraToken(email, password);
            }
            catch (Exception ex)
            { 
                DisplayMensaje(ex.Message.ToString());
                return;
            }
            //if (email != "5542" || password != "3322376")  
            //{  
            //    DisplayInvalidLoginPrompt();
            //}
            //else
            //{
            //    Loggeado();
            //}
        }  
    }  
}  