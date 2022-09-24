using System;

namespace BovinoRemoto.App.Dominio
{
    public class Vaca
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public string Color { get; set; }
        public string Especie { get; set; }
        public string Raza { get; set; }
        public bool veterinarioAsignado { get; set; }
        public Historia_Clinica HistoriaClinica { get; set; }
    }
}
