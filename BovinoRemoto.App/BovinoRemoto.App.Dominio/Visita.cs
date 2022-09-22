namespace BovinoRemoto.App.Dominio
{
    public class Visita
    {
        public int Id { get; set; }
        public List<Signo_Vital> SignosVitales { get; set; }
        public string EstadoAnimo { get; set; }
        public List<Recomendacion> Recomendaciones { get; set; }
    }
}