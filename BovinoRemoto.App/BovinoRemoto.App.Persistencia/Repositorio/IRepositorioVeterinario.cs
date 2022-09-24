using BovinoRemoto.App.Dominio;

namespace BovinoRemoto.App.Persistencia
{
    public interface IRepositorioVeterinario
    {
        Veterinario AddVeterinario(Veterinario veterinario);
        void DeleteVeterinario(int idveterinario);
        IEnumerable<Veterinario> GetAllVeterinarios();
        Veterinario GetVeterinario(int idveterinario);
        Veterinario GetVeterinario(Vaca bovino);
        Veterinario GetVeterinarioPorCedula(int Num_Identificacion);
        Veterinario UpdateVeterinario(Veterinario veterinario);
    }
}