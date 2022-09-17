using BovinoRemoto.App.Dominio;
namespace BovinoRemoto.App.Persistencia
{
    public interface IRepositorioBovino
    {
        Vaca AddVaca(Vaca vaca);
        void DeleteVaca(int idvaca);
        IEnumerable<Vaca> GetAllVacas();
        Vaca GetVaca(int idvaca);
        IEnumerable<Vaca> GetVacasPorDueño(int iddueño);
        Vaca UpdateVaca(Vaca vaca);
    }
}