using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPPatioAsociado.Models
{
      class VariablesGlobales
    {
        public static string AppKey = "A70F5BA0-3541-492C-802F-087FE810184A";
        public static string ServidorJsonServicios = "https://krakenapi.deacero.com/SandboxServices/";  // * Versión de Pruebas:
        public static string ServidorJsonAutenticacion = "https://sweetsrv.azurewebsites.net/LoginSandbox/";  // * Versión de Pruebas:

        public static string ServicioAutenticacion = "authenticate";
        public static AuthenticateKraken Autenticacion = new AuthenticateKraken { mensaje = "ERROR" };
        public static SAMPPatioAsociado.Services.ConsumirServicio Consumo = new SAMPPatioAsociado.Services.ConsumirServicio();

        public static ElementodeTrabajo EntidadTrabajo = new ElementodeTrabajo();
    }
}
