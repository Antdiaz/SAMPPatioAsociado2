using System;
using System.Collections.Generic;
using System.Text;

using RestSharp;
using System.Threading;
using Newtonsoft.Json;
using SAMPPatioAsociado.Models;
using System.Threading.Tasks;
using Xamarin.Forms;


namespace SAMPPatioAsociado.Services
{
    class ConsumirServicio
    {
        public async Task<string> ConsumeServicioExecSwitch(string request, object ObjParametros)//, int servicio)
        {// Metodo Nuevo para validar si se trabajará en linea o no, es parecido al metodo ConsumeServicioExec solo que
            //recibe un parametro extra para poder consultar el objeto local (si es off line), el parametro extra es servicio
            //y si es tabajo offlinea ese servicio regresa un objeto valido para ese servicio.

            IRestResponse respuesta = null;

            var cliente = new RestClient(VariablesGlobales.ServidorJsonServicios);
            var solicitud = new RestRequest(request, Method.POST);
            solicitud.AddHeader("Content-Type", "application/json");
            solicitud.AddHeader("x-api-key", VariablesGlobales.AppKey);
            solicitud.AddHeader("x-access-token", VariablesGlobales.Autenticacion.token);
            solicitud.AddJsonBody(ObjParametros);

            var tokenCancelacion = new CancellationTokenSource();

            IRestResponse respuestal = await cliente.ExecuteTaskAsync(solicitud, tokenCancelacion.Token);

            // respuesta = await cliente.ExecuteTaskAsync(solicitud, tokenCancelacion.Token);

            respuesta = respuestal;
            if (respuesta.Content.Contains("jwt expired"))// expiró el Token, se genera error
            {
                throw new Exception("Token Expirado");
            }


            return respuesta.Content;

        }

        public async Task<string> ConsumeServicioporIDLogin(string Usuario, string Password)
        {

            var cliente = new RestClient(VariablesGlobales.ServidorJsonAutenticacion);
            var solicitud = new RestRequest(VariablesGlobales.ServicioAutenticacion, Method.POST);
            solicitud.AddJsonBody(new LoginKraken { userName = Usuario, password = Password });

            var tokenCancelacion = new CancellationTokenSource();
            IRestResponse respuesta = await cliente.ExecuteAsync(solicitud, tokenCancelacion.Token);
            return respuesta.Content;
        }
    }
}
