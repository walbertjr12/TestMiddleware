using SmartAdminMvc.Clases;
using SmartAdminMvc.Database;
using SmartAdminMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        private PruebaAdmisionEntities db;

        public DepartamentosController()
        {
            db = new PruebaAdmisionEntities();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: Departamentos
        public ActionResult Index()
        {
            return View();
        }

        public JsonResult GetDepartamentos()
        {
            var departamentos = db.DEPARTAMENTOS.Select(x=> new DepartamentoViewModel() { DESCRIPCION= x.DESCRIPCION, NOMBRE = x.NOMBRE, REFERENCIA= x.REFERENCIA, ID_DEPARTAMENTO = x.ID_DEPARTAMENTO }).ToList();
            var jsonResult = Json(new { data = departamentos }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }

        public PartialViewResult FormDepartamento()
        {
            return PartialView();
        }

        public JsonResult Save(DepartamentosViewModel departamento)
        {
            ResponseResult response = new ResponseResult() { Message ="", Result = false };

            var departamentoinDb = new DEPARTAMENTOS() { REFERENCIA = departamento.REFERENCIA, DESCRIPCION = departamento.DESCRIPCION, NOMBRE = departamento.NOMBRE };

            db.DEPARTAMENTOS.Add(departamentoinDb);
            db.SaveChanges();

            if (departamento != null)
            {
                if (departamento.EMPLEADOS.Count() > 0)
                {
                    foreach (var item in departamento.EMPLEADOS)
                    {
                        db.EMPLEADOS.Add(new EMPLEADOS() { DESCRIPCION = item.DESCRIPCION, FECHA_NACIMIENTO = item.FECHA_NACIMIENTO, GENERO_SEXO = item.GENERO_SEXO, ID_DEPARTAMENTO = departamentoinDb.ID_DEPARTAMENTO, NOMBRE= item.NOMBRE });
                        db.SaveChanges();
                    }
                }
            }

            response.Message = "Departamento almacenado correctamente";
            response.Result = true;

            var jsonResult = Json(new { data = response }, JsonRequestBehavior.AllowGet);
            jsonResult.MaxJsonLength = int.MaxValue;

            return jsonResult;
        }
    }
}