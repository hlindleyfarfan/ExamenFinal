using Factoring.Web.Funcionalidades.EditarEmpresa;
using Factoring.Web.Funcionalidades.ListarEmpresa;
using Factoring.Web.Funcionalidades.ListarFactura;
using Factoring.Web.Funcionalidades.RegistrarEmpresa;
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
                //filtroCoUser = "HL";
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

        [HttpGet]
        public PartialViewResult Editar(int NuEmpresa)
        {
            using (var buscar = new VerEmpresaHandler())
            {
                return PartialView("Editar", buscar.Execute(NuEmpresa));
            }
        }

        [HttpPost]
        public ActionResult Editar(EditarEmpresaViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            using (var editar = new EditarEmpresaHandler())
            {
                try
                {
                    editar.Ejecutar(model);

                    return RedirectToAction("Lista", new { filtroCoUser = model.CoUser });

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }

            }


        }


        [HttpGet]
        public ActionResult Registrar()
        {
            return View(new RegistrarEmpresaViewModel());
        }

        [HttpPost]
        public ActionResult Registrar(RegistrarEmpresaViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            using (var registrar = new RegistrarEmpresaHandler())
            {
                try
                {
                    registrar.Ejecutar(model);

                    return RedirectToAction("Lista", new { filtroCoUser = model.CoUser });

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }

            }


        }

        [HttpGet]
        public PartialViewResult ListarDetalle(int filtroNuEmpresa)
        {
            using (var listar = new ListarFacturaHandler())
            {

                return PartialView("_ListaFacturasxEmpresa",
                        listar.Ejecutar(filtroNuEmpresa)
                    );
            }
        }

        [HttpPost]
        public ActionResult ListarDetalle()
        {

            return RedirectToAction("Lista", new {filtroCoUser = "HL" });

        }

        [HttpGet]
        public PartialViewResult Eliminar(int NuEmpresa)
        {
            using (var buscar = new VerEmpresaHandler())
            {
                return PartialView("Eliminar", buscar.Execute(NuEmpresa));
            }
        }
        [HttpPost]
        public ActionResult Eliminar(EditarEmpresaViewModel model)
        {
            if (!ModelState.IsValid) return View(model);

            using (var eliminar = new EliminarEmpresaHandler())
            {
                try
                {
                    eliminar.Ejecutar(model);
                    return RedirectToAction("Lista", new { filtroCoUser = model.CoUser });

                }
                catch (Exception ex)
                {
                    ModelState.AddModelError("", ex.Message);
                    return View(model);
                }

            }


        }
    }
}