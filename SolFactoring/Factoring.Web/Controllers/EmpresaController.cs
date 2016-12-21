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

                return View(new FiltrarEmpresaViewModel()
                {
                    FiltroCoUser = string.Empty,
                    Empresas = listar.Ejecutar(filtroCoUser)
                });
            }
        }
    }
}