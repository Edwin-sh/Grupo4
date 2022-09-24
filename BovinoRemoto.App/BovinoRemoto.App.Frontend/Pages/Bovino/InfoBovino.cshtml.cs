using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class InfoBovinoModel : PageModel
    {
        private readonly IRepositorioBovino repositorioBovino;
        private readonly IRepositorioDueño repositorioDueño;
        private readonly IRepositorioVeterinario repositorioVeterinario;
        public InfoBovinoModel()
        {
            this.repositorioBovino = new RepositorioBovino(new Persistencia.AppContext());
            this.repositorioDueño = new RepositorioDueño(new Persistencia.AppContext());
            this.repositorioVeterinario = new RepositorioVeterinario(new Persistencia.AppContext());
        }
        //[BindProperty]
        public Vaca Bovino { get; set; }
        [BindProperty]
        public Dueño Dueño { get; set; }
        [BindProperty]
        public Veterinario Veterinario { get; set; }
        [BindProperty]
        public string origen { get; set; }

        public void OnGet(int idbovino, int? idveterinario, string origen)
        {
            Bovino = repositorioBovino.GetVaca(idbovino);
            Dueño = repositorioDueño.GetDueño(Bovino);
            if (idveterinario == null)
            {
                Veterinario = repositorioVeterinario.GetVeterinario(Bovino);
                if (Veterinario == null)
                {
                    Veterinario = new Veterinario() { Nombres = "Sin", Apellidos = "Asignar" };
                }
            }
            else
            {
                Veterinario = repositorioVeterinario.GetVeterinario(idveterinario.Value);
            }
            this.origen = origen;
        }

        public IActionResult OnPost()
        {
            if (origen.Equals("Veterinario"))
            {
                return RedirectToPage("./ListarPorVeterinario", new { idveterinario = Veterinario.Id }
                );
            }
            else if (origen.Equals("Dueño"))
            {
                return RedirectToPage("./ListarPorDueño", new { iddueño = Dueño.Id }
                );
            }
            else
            {
                return RedirectToPage("./AsignarBovino", new { idveterinario = Veterinario.Id }
                );
            }
        }
    }
}
