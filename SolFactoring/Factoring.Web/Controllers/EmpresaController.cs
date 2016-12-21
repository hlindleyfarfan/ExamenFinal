using Factoring.Web.Funcionalidades.ListarEmpresa;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Factoring.Web.Controllers
{
    public class EmpresaController : Controller
    {
        // GET: Empresa
        public ActionResult Lista(string filtroCoUser)
        {
            using (var listar = new ListarEmpresaHandler())
            {
                filtroCoUser = "HL";
                return View(new FiltrarEmpresaViewModel()
                {
                    FiltroCoUser = string.Empty,                    
                    Empresas = listar.Ejecutar(filtroCoUser)
                });
            }
        }

        public PartialViewResult VerEmpresas(string filtroCoUser)
        {
            using (var listar = new ListarEmpresaHandler())
            {

                return PartialView("_EmpresasEncontradas",
                        listar.Ejecutar(filtroCoUser)
                    );
            }
        }
    }
}