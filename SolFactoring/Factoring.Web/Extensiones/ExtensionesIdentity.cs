using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace Microsoft.AspNet.Identity
{
    public static class ExtensionesIdentity
    {
        public static string MostrarNombre(this IPrincipal usuario)
        {
            if (!usuario.Identity.IsAuthenticated) return string.Empty;

            var claimIdentity = usuario.Identity as ClaimsIdentity;

            if (claimIdentity == null) return string.Empty;

            var nombre = claimIdentity.Claims.SingleOrDefault(x => x.Type == "Nombre");

            return nombre == null ? "No Encontrado" : nombre.Value;

        }

        public static string NombreUsuario(this IPrincipal usuario)
        {
            if (!usuario.Identity.IsAuthenticated) return string.Empty;
            return usuario.Identity.Name;
        }
        public static IList<string> Roles(this IPrincipal usuario)
        {
            if (!usuario.Identity.IsAuthenticated) return new List<string>();

            var claimIdentity = usuario.Identity as ClaimsIdentity;

            if (claimIdentity == null) return new List<string>();

            return claimIdentity
                        .Claims
                        .Where(x => x.Type == ClaimTypes.Role)
                        .Select(c => c.Value).ToList();
        }
    }
}
