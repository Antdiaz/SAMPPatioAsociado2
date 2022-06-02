using System;
using System.Collections.Generic;
using System.Text;


namespace SAMPPatioAsociado.Models
{
    class RespuestaMateriales
    {
        public string message { get; set; }
        public List<Material> Result0 { get; set; }
    }
    public class Material
    {
        public int ClaArticuloCompra { get; set; }

        public string NomArticuloCompra { get; set; }
        public string NomCorto { get; set; }



    }



}