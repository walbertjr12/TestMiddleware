using Newtonsoft.Json;
using SmartAdminMvc.Clases;
using SmartAdminMvc.Database;
using SmartAdminMvc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace SmartAdminMvc.Controllers
{
    public class DepartamentosController : Controller
    {
        private PruebaAdmisionEntities db;
        private string URI = "https://localhost:44392/";
        private static readonly HttpClient client = new HttpClient();

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

        public async Task<JsonResult> GetDepartamentos()
        {
            try
            {
                client.DefaultRequestHeaders.Clear();

                var response = await client.GetAsync(URI + "api/Departamentos");

                if (response.StatusCode == HttpStatusCode.OK)
                {
                    string result = await response.Content.ReadAsStringAsync();
                    var departamentoslist = JsonConvert.DeserializeObject<List<DepartamentoViewModel>>(result);

                    return Json(new { data = departamentoslist }, JsonRequestBehavior.AllowGet);
                }
                else
                {
                    return Json(new ResponseResult { Result = false, Message = response.StatusCode.ToString() });
                }
            }
            catch (Exception e)
            {
                return Json(new ResponseResult { Result = false, Message = e.ToString() });
            }
        }

        public PartialViewResult FormDepartamento()
        {
            return PartialView();
        }

        public async Task<JsonResult> Save(DepartamentosViewModel departamento)
        {
            string content = JsonConvert.SerializeObject(departamento);
            HttpContent httpContent = new StringContent(content, Encoding.UTF8, "application/json");

            var responseCreationFields = await client.PostAsync(URI + "api/Departamentos", httpContent);
            if (responseCreationFields.StatusCode == HttpStatusCode.OK)
            {
                string result = await responseCreationFields.Content.ReadAsStringAsync();
                var response = JsonConvert.DeserializeObject<ResponseResult>(result);

                return Json(new { data = response }, JsonRequestBehavior.AllowGet);
            }
            else
            {
                return Json(new ResponseResult { Result = false, Message = responseCreationFields.StatusCode.ToString() });
            }
        }
    }
}