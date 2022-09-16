using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages.Bovino
{
    public class ListarPorVeterinarioModel : PageModel
    {
        private readonly string[] Bovinos = { "Bovino a cargo 1", "Bovino a cargo 2", "Bovino a cargo 3" };
        public List<String>? AllBovinos { get; set; }

        public void OnGet()
        {
            AllBovinos = new List<string>();
            AllBovinos.AddRange(Bovinos);
        }
    }
}
