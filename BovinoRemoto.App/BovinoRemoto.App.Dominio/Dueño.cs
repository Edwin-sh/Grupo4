using System;

namespace BovinoRemoto.App.Dominio
{
    public class Dueño : Persona
    {
        public string Correo { get; set; }

        public List<Vaca> Bovinos { get; set; }
    }
}
