using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class PrincipalVeterinarioModel : PageModel
    {
        private readonly IRepositorioVeterinario repositorioVeterinario;

        public PrincipalVeterinarioModel()
        {
            this.repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        [BindProperty]
        public Veterinario Veterinario { set; get; }
        public IActionResult OnGet(int? numIdentificacion, int? idveterinario)
        {
            if (numIdentificacion!=null)
            {
                Veterinario = repositorioVeterinario.GetVeterinarioPorCedula
            (numIdentificacion.Value);
                if (Veterinario != null)
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
                Veterinario = repositorioVeterinario.GetVeterinario(idveterinario.Value);
                return Page();
            }
        }

        public IActionResult OnPost()
        {
            Veterinario.BovinosaCargo = repositorioVeterinario.GetVeterinario(Veterinario.Id).BovinosaCargo;
            repositorioVeterinario.UpdateVeterinario(Veterinario);
            return RedirectToPage("./PrincipalVeterinario", new { idveterinario = Veterinario.Id});
        }
    }
}
