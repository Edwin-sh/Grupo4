using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class AccederVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;

        public AccederVeterinarioModel()
        {
            this.repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        [BindProperty]
        public Veterinario Veterinario { set; get; }
    }
}
