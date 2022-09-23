using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class EditBovinoModel : PageModel
    {
        private readonly IRepositorioBovino repositorioBovino;
        private readonly IRepositorioDueño repositorioDueño;
        public EditBovinoModel()
        {
            this.repositorioBovino = new RepositorioBovino(new Persistencia.AppContext());
            this.repositorioDueño = new RepositorioDueño(new Persistencia.AppContext());
        }
        [BindProperty]
        public Vaca Bovino { get; set; }
        [BindProperty]
        public Dueño Dueño { get; set; }

        public void OnGet(int idbovino)
        {
            Bovino = repositorioBovino.GetVaca(idbovino);
            Dueño = repositorioDueño.GetDueño(Bovino);
        }

        public IActionResult OnPost()
        {
            var bovinoEditado = repositorioBovino.UpdateVaca(Bovino);
            if (bovinoEditado != null)
            {
                return RedirectToPage("./ListarPorDueño", new { iddueño = Dueño.Id });
            }
            else
            {
                return Page();
            }
        }
    }
}