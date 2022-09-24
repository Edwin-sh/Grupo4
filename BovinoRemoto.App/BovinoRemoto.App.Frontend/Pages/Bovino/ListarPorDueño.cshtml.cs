using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class ListarPorDueñoModel : PageModel
    {
        private readonly IRepositorioDueño repositorioDueño;
        private readonly IRepositorioBovino repositorioBovino;

        public ListarPorDueñoModel()
        {
            this.repositorioDueño = new RepositorioDueño(new Persistencia.AppContext());
            this.repositorioBovino = new RepositorioBovino(new Persistencia.AppContext());
        }
        [BindProperty]
        public Dueño Dueño { get; set; }
        public IEnumerable<Vaca> Bovinos { get; set; }
        [BindProperty]
        public Vaca Bovino { get; set; }

        public void OnGet(int? iddueño)
        {
            if (iddueño != null)
            {
                Dueño = repositorioDueño.GetDueño(iddueño.Value);
                Bovinos = repositorioBovino.GetVacasPorDueño(iddueño.Value);
            }
            else
            {
                Dueño = new Dueño()
                {
                    Id = 0
                };
            }
        }

        public IActionResult OnPost()
        {
            repositorioBovino.DeleteVaca(Bovino.Id);
            return RedirectToPage("./ListarPorDueño", new { iddueño = Dueño.Id});
        }
    }
}
