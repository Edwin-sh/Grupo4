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

        public Dueño Dueño { get; set; }
        public IEnumerable<Vaca> Bovinos { get; set; }

        public void OnGet(int ?iddueño)
        {
            Dueño = repositorioDueño.GetDueño(iddueño.Value);
            Bovinos = repositorioBovino.GetVacasPorDueño(iddueño.Value);
        }

    }
}
