using System;
using System.Collections.Generic;
using System.Text;

namespace SAMPPatioAsociado.Models
{
    class RespuestaProveedores
    {
        public string message { get; set; }
        public List<Proveedor> Result0 { get; set; }
    }
    public class Proveedor
    {
        public int ClaUbiAsociado { get; set; }

        public int ClaProveedor { get; set; }

        public string NombreProveedor { get; set; }

    }
}
