using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class AccederDueñoModel : PageModel
    {
        private readonly IRepositorioDueño repositorioDueño;

        public AccederDueñoModel()
        {
            this.repositorioDueño = new RepositorioDueño(new Persistencia.AppContext());
        }
        [BindProperty]
        public Dueño Dueño { set; get; }


    }
}
