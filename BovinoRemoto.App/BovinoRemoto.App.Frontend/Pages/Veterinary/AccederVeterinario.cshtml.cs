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
        public void OnGet()
        {

        }
        public IActionResult OnPost()
        {
            var dEncontrado = repositorioVeterinario.GetVeterinarioPorCedula(Veterinario.Num_Identificacion);
            if (dEncontrado != null)
            {
                return RedirectToPage("./PrincipalVeterinario", new { numIdentificacion = Veterinario.Num_Identificacion });
            }
            else
            {
                return RedirectToPage("../NotFound");
            }
        }
    }
}
