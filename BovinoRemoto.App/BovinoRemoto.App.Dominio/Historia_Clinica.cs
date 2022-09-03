namespace BovinoRemoto.App.Dominio
{
    public class Historia_Clinica
    {
        public int Id { get; set; }
        public DateTime FechaCreacion { get; set; }
        public List<Visita> Visitas { get; set; }        
    }
}