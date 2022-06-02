using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPPatioAsociado.Models
{
      class FunGenerica
    {
        public string GetVersion()
        {
            //string v = Xamarin.Forms.DependencyService.Get<IAppVersion>().GetVersion();
            //int b = DependencyService.Get<IAppVersion>().GetBuild();
            return "";
        }
        public string FnEliminaCaracter(string valor)
        {
            if (valor == null) { return valor; }
            valor = valor.Replace("#", "%23");
            valor = valor.Replace("\"", "%22");
            valor = valor.Replace("\t", "");
            valor = valor.Replace("\n", "");
            valor = valor.Replace("\r", "");
            valor = valor.Replace(System.Environment.NewLine, " ");
            return valor;
        }
        public string FnEliminaCaracter2(string valor)
        {
            if (valor == null) { return "NULL"; }
            valor = valor.Replace("#", "%23");
            valor = valor.Replace("\"", "%22");
            valor = valor.Replace("\t", "");
            valor = valor.Replace("\n", "");
            valor = valor.Replace("\r", "");
            return "'" + valor + "'";
        }
        public string FnValidaNuloTexto(string valor)
        {
            if (valor == null || valor.Trim() == "") { return "NULL"; }
            return "'" + valor + "'";
        }
        public string GetIP2()
        {
            string MyIp = "";

            foreach (System.Net.IPAddress adress in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()))
            {
                MyIp = "'App:" + adress.ToString() + "'";

                break;
            }
            return MyIp;
        }
        public string GetIP()
        {
            string MyIp = "";

            foreach (System.Net.IPAddress adress in System.Net.Dns.GetHostAddresses(System.Net.Dns.GetHostName()))
            {
                MyIp = "App:" + adress.ToString();

                break;
            }
            return MyIp;
        }
         
        public string GetValueOrDefault(string extendee, string defaultValue)
        {

            if (string.IsNullOrEmpty(extendee)) { return defaultValue; }
            return extendee;
        }
        public string GetValueOrDefaultInt(int extendee, string defaultValue)
        {

            if (extendee == null || extendee == 0) { return defaultValue; }
            return extendee.ToString();
        }
        public string GetValueOrDefaultKgsContaminados(decimal kgs)
        {

            string final = "";
            if (kgs == null || kgs == 0) { return ""; }
            else
            {
                final = kgs.ToString("0,0", System.Globalization.CultureInfo.InvariantCulture);
                return "Kilos Contaminados  " + final;
            }
        }
        public string GetValueOrDefaultObs(string obs)
        {
            string final = "";
            if (obs == null || obs.Trim() == "") { return "Obs: Ninguna"; }
            else
            {
                if (obs.Length > 9) { final = "Obs: " + obs.Substring(0, 10) + " ..."; }
                else { final = "Obs: " + obs + " ..."; }

                return final;
            }
        }
        public string GetValueOrDefaultKgs(decimal kgs)
        {

            string final = "";
            if (kgs == null || kgs == 0) { return ""; }
            else
            {
                final = kgs.ToString("0,0", System.Globalization.CultureInfo.InvariantCulture);
                return "Kilos Elec/Bote  " + final;
            }
        }
        public string GetFormatoInt(int extendee, string defaultValue)
        {
            string final = "";
            if (extendee == null || extendee == 0) { return defaultValue; }
            final = extendee.ToString("0,0", System.Globalization.CultureInfo.InvariantCulture);

            return final;//;extendee.ToString();
        }
    }
}
