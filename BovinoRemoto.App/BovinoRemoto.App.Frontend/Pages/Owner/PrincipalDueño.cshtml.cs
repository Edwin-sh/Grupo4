using System.Linq;
using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class PrincipalDueñoModel : PageModel
    {
        private readonly IRepositorioDueño repositorioDueño;

        public PrincipalDueñoModel()
        {
            this.repositorioDueño = new RepositorioDueño(new Persistencia.AppContext());
        }
        public Dueño Dueño { set; get; }
        public void OnGet(int numIdentificacion)
        {
            Dueño = repositorioDueño.GetDueñoPorCedula(numIdentificacion);
        }
    }
}
