using BovinoRemoto.App.Dominio;
namespace BovinoRemoto.App.Persistencia
{
    public interface IRepositorioBovino
    {
        Vaca AddVaca(Vaca bovino, int iddueño);
        Vaca AsignarVeterinario(int idveterinario, Vaca bovino);
        Vaca EliminarVeterinario(int idveterinario, Vaca bovino);
        void DeleteVaca(int idvaca);
        IEnumerable<Vaca> GetAllVacas();
        Vaca GetVaca(int idvaca);
        IEnumerable<Vaca> GetVacasSinAsignar();
        IEnumerable<Vaca> GetVacasPorDueño(int iddueño);
        IEnumerable<Vaca> GetVacasPorVeterinario(int idveterinario);
        Vaca UpdateVaca(Vaca vaca);
    }
}