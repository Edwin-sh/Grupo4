using System;

namespace BovinoRemoto.App.Dominio
{
    public class Veterinario : Persona
    {
        public string TarjetaProfesional { get; set; }
        public List<Vaca> BovinosaCargo { get; set; }
    }
}
