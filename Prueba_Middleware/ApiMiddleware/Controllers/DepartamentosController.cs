using ApiMiddleware.Clases;
using ApiMiddleware.DataBase;
using ApiMiddleware.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace ApiMiddleware.Controllers
{
    public class DepartamentosController : ApiController
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
        // GET: api/Departamentos
        public List<DepartamentoViewModel> Get()
        {
            var departamentos = db.DEPARTAMENTOS.Select(x => new DepartamentoViewModel() { DESCRIPCION = x.DESCRIPCION, NOMBRE = x.NOMBRE, REFERENCIA = x.REFERENCIA, ID_DEPARTAMENTO = x.ID_DEPARTAMENTO }).ToList();

            return departamentos;
        }

        // GET: api/Departamentos/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Departamentos
        public ResponseResult Post([FromBody]DepartamentosViewModel departamento)
        {
            ResponseResult response = new ResponseResult() { Message = "", Result = false };

            var departamentoinDb = new DEPARTAMENTOS() { REFERENCIA = departamento.REFERENCIA, DESCRIPCION = departamento.DESCRIPCION, NOMBRE = departamento.NOMBRE };

            try
            {
                db.DEPARTAMENTOS.Add(departamentoinDb);
                db.SaveChanges();

                if (departamento != null)
                {
                    if (departamento.EMPLEADOS.Count() > 0)
                    {
                        foreach (var item in departamento.EMPLEADOS)
                        {
                            db.EMPLEADOS.Add(new EMPLEADOS() { DESCRIPCION = item.DESCRIPCION, FECHA_NACIMIENTO = item.FECHA_NACIMIENTO, GENERO_SEXO = item.GENERO_SEXO, ID_DEPARTAMENTO = departamentoinDb.ID_DEPARTAMENTO, NOMBRE = item.NOMBRE });
                            db.SaveChanges();
                        }
                    }
                }

                response.Message = "Departamento almacenado correctamente";
                response.Result = true;
            }
            catch (Exception E)
            {
                response.Message = "Departamento no almacenado correctamente, debe ingresar todos los datos de los empleados";
            }
            return response;
        }

        // PUT: api/Departamentos/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Departamentos/5
        public void Delete(int id)
        {
        }
    }
}
