using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class ListarPorVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;
        private readonly IRepositorioBovino repositorioBovino;

        public ListarPorVeterinarioModel()
        {
            this.repositorioVeterinario = new RepositorioVeterinario (new Persistencia.AppContext());
            this.repositorioBovino = new RepositorioBovino(new Persistencia.AppContext());
        }
        [BindProperty]
        public Veterinario Veterinario { get; set; }
        public IEnumerable<Vaca> Bovinos { get; set; }
        [BindProperty]
        public Vaca Bovino { get; set; }

        public void OnGet(int? idveterinario)
        {
            if (idveterinario != null)
            {
                Veterinario = repositorioVeterinario.GetVeterinario(idveterinario.Value);
                Bovinos = repositorioBovino.GetVacasPorVeterinario(idveterinario.Value);
            }
            else
            {
                Veterinario = new Veterinario()
                {
                    Id = 0
                };
            }
        }

        public IActionResult OnPost()
        {
            var BovinoEncontrado = repositorioBovino.GetVaca(Bovino.Id);
            repositorioBovino.EliminarVeterinario(Veterinario.Id, BovinoEncontrado);
            return RedirectToPage("./ListarPorVeterinario", new { idveterinario = Veterinario.Id});
        }
    }
}
