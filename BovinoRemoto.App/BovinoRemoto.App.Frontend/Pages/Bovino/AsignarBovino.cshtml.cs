using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class AsignarBovinoModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        private readonly IRepositorioBovino repositorioBovino;
        public AsignarBovinoModel()
        {
            this.repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
            this.repositorioBovino = new RepositorioBovino(new Persistencia.AppContext());
        }
        public IEnumerable<Vaca> Bovinos { get; set; }
        [BindProperty]
        public Vaca Bovino { get; set; }
        [BindProperty]
        public Veterinario Veterinario { get; set; }
        public void OnGet(int? idveterinario)
        {
            Veterinario = repositorioVeterinario.GetVeterinario(idveterinario.Value);
            Bovinos = repositorioBovino.GetVacasSinAsignar();
        }

        public IActionResult OnPost()
        {
            var BovinoEncontrado = repositorioBovino.GetVaca(Bovino.Id);
            repositorioBovino.AsignarVeterinario(Veterinario.Id, BovinoEncontrado);
            return RedirectToPage("./AsignarBovino", new { idveterinario = Veterinario.Id });
        }
    }
}
