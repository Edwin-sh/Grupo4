using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class NuevoBovinoModel : PageModel
    {
        private readonly IRepositorioDueño repositorioDueño;
        private readonly IRepositorioBovino repositorioBovino;

        public NuevoBovinoModel()
        {
            this.repositorioDueño = new RepositorioDueño(new Persistencia.AppContext());
            this.repositorioBovino = new RepositorioBovino(new Persistencia.AppContext());
        }

        public Dueño Dueño { get; set; }
        [BindProperty]
        public Vaca Bovino { get; set; }

        public void OnGet(int iddueño)
        {
            this.Dueño = repositorioDueño.GetDueño(iddueño);            
        }

        public IActionResult OnPost()
        {
            Vaca vAdicionado=repositorioBovino.AddVaca(Bovino);
            vAdicionado.Dueño = this.Dueño;
            repositorioBovino.UpdateVaca(vAdicionado);
            return Page();
        }
    }
}
