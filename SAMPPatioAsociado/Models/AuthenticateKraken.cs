using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPPatioAsociado.Models
{
    public class AuthenticateKraken
    {
        public string token { get; set; }
        public string mensaje { get; set; }
        public string NombreUsuario { get; set; }
        
        public int EsValido { get; set; }
        public int ClaUbiAsociadoUsuario { get; set; }  
        public string ApellidoPaterno { get; set; }
        public string ApellidoMaterno { get; set; }
        public int ClaUbiAsociadoDefault { get; set; }
        //public string Email { get; set; }
        //public string LoginUserName { get; set; }
        //public int ClaIdiomaDefault { get; set; }

        public string AppVersion { get; set; }
        public int ClaUbiAsociado { get; set; }// Ubicacion de Trabajo
        //public string NomUbicacion { get; set; }
        public string statusCode { get; set; }
        public string message { get; set; }
        public bool EsOffline { get; set; }
        public bool EsSincroniza { get; set; } 
    }
}
