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
        [BindProperty]
        public Dueño Dueño { set; get; }
        public IActionResult OnGet(int? numIdentificacion, int? iddueño)
        {
            if (numIdentificacion != null)
            {
                Dueño = repositorioDueño.GetDueñoPorCedula
            (numIdentificacion.Value);
                if (Dueño != null)
                {
                    return Page();
                }
                else
                {
                    return RedirectToPage("../NotFound");
                }
            }
            else
            {
                Dueño = repositorioDueño.GetDueño(iddueño.Value);
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            Dueño.Bovinos = repositorioDueño.GetDueño(Dueño.Id).Bovinos;
            repositorioDueño.UpdateDueño(Dueño);
            return RedirectToPage("./PrincipalDueño", new { iddueño = Dueño.Id });
        }
    }
}
