namespace BovinoRemoto.App.Dominio
{
    public class HistoriaClinica
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<Visita> Visitas { get; set; }        
    }
}