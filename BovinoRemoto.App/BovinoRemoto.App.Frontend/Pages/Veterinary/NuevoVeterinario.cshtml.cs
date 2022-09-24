using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BovinoRemoto.App.Persistencia;
using BovinoRemoto.App.Dominio;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class NuevoVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;

        public NuevoVeterinarioModel()
        {
            this.repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        [BindProperty]
        public Veterinario Veterinario { set; get; }

        public void OnGet()
        {
        }

        public IActionResult OnPost()
        {
            Veterinario veterinario = repositorioVeterinario.AddVeterinario(Veterinario);
            if (veterinario != null)
            {
                return RedirectToPage("../Index");
            }
            else
            {
                return Page();
            }
        }
    }
}
