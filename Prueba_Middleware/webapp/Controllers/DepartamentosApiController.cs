using SmartAdminMvc.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace SmartAdminMvc.Controllers
{
    public class DepartamentosApiController : ApiController
    {
        private PruebaAdmisionEntities db;

        public DepartamentosApiController()
        {
            db = new PruebaAdmisionEntities();
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
        }

        // GET: api/DepartamentosApi
        public List<DEPARTAMENTOS> Get()
        {
            return db.DEPARTAMENTOS.ToList();
        }

        // GET: api/DepartamentosApi/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/DepartamentosApi
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/DepartamentosApi/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/DepartamentosApi/5
        public void Delete(int id)
        {
        }
    }
}
