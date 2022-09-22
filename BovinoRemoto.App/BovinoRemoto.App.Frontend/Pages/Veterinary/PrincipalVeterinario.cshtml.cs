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
        public Veterinario Veterinario { set; get; }
        public void OnGet()
        {
            int N_Identificacion = int.Parse(Request.Query["N_Identificacion"]);
            Veterinario = repositorioVeterinario.GetVeterinarioPorCedula(N_Identificacion);
        }
    }
}
