using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace BovinoRemoto.App.Frontend.Pages.Bovino
{
    public class ListarPorDueñoModel : PageModel
    {
        private readonly string[] Bovinos = { "Bovino1", "Bovino2", "Bovino3" };
        public List<String>? AllBovinos { get; set; }


        public void OnGet()
        {
            AllBovinos = new List<string>();
            AllBovinos.AddRange(Bovinos);
        }

    }
}
