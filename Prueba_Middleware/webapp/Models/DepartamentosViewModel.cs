using SmartAdminMvc.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SmartAdminMvc.Models
{
    public class DepartamentosViewModel
    {
        public int ID_DEPARTAMENTO { get; set; }
        public string NOMBRE { get; set; }
        public string REFERENCIA { get; set; }
        public string DESCRIPCION { get; set; }
        public List<EMPLEADOS> EMPLEADOS { get; set; }
    }
}