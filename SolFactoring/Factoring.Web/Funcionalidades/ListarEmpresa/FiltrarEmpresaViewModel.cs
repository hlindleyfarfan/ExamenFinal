using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Factoring.Web.Funcionalidades.ListarEmpresa
{
    public class FiltrarEmpresaViewModel
    {
        public string FiltroCoUser { get; set; }
        public IEnumerable<ListarEmpresaViewModel> Empresas { get; set; }

        public FiltrarEmpresaViewModel()
        {

            Empresas = new List<ListarEmpresaViewModel>();

        }
    }
}