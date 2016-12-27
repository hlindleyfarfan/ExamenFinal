using Factoring.Web.XmlHelpers;
using System.IO;
using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace AwSales.Web.Controllers
{
    public class UbigeoController : Controller
    {
        private UbigeoHelper _ubigeoHelper;

        protected override void Initialize(RequestContext requestContext)
        {
            base.Initialize(requestContext);
            _ubigeoHelper = new UbigeoHelper(
                Path.Combine(Server.MapPath("~/App_Data"), "Ubigeo.xml")
                );
        }

        [HttpGet]
        public JsonResult Departamentos()
        {
            // Json(elObjetoquequierendevolverenformatoJson, JsonRequestBehavior.AllowGet);
            return Json(_ubigeoHelper
                            .GetDepartamentos()
                            .ToList(),
                       JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Provincias(string departamento)
        {
            // Json(elObjetoquequierendevolverenformatoJson, JsonRequestBehavior.AllowGet);
            return Json(_ubigeoHelper
                            .GetProvincias(departamento)
                            .ToList(),
                        JsonRequestBehavior.AllowGet);
        }


        [HttpGet]
        public JsonResult Distritos(string departamento, string provincia)
        {
            // Json(elObjetoquequierendevolverenformatoJson, JsonRequestBehavior.AllowGet);
            return Json(_ubigeoHelper
                            .GetDistritos(departamento, provincia)
                            .ToList(),
                       JsonRequestBehavior.AllowGet);
        }
    }
}