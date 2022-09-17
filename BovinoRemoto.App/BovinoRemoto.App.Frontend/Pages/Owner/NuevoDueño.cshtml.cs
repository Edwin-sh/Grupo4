using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BovinoRemoto.App.Dominio;
using BovinoRemoto.App.Persistencia;

//LIbrerias opcionales
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BovinoRemoto.App.Frontend.Pages
{
    public class NuevoDueñoModel : PageModel
    {
        private readonly IRepositorioDueño repositorioDueño;

        public NuevoDueñoModel()
        {
            this.repositorioDueño = new RepositorioDueño(new Persistencia.AppContext());
        }
        [BindProperty]
        public Dueño Dueño { set; get; }

        public void OnGet()
        {

        }

        public IActionResult OnPost()
        {
            Dueño dueño = repositorioDueño.AddDueño(Dueño);
            if (dueño != null)
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
