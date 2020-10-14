using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ApiMiddleware.Models
{
    public class DepartamentoViewModel
    {
        public int ID_DEPARTAMENTO { get; set; }
        public string NOMBRE { get; set; }
        public string REFERENCIA { get; set; }
        public string DESCRIPCION { get; set; }
    }
}