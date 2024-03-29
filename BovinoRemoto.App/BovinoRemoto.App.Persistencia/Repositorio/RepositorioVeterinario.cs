using BovinoRemoto.App.Dominio;

namespace BovinoRemoto.App.Persistencia
{
    public class RepositorioVeterinario : IRepositorioVeterinario
    {
        public readonly AppContext _appContext;

        public RepositorioVeterinario(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Veterinario AddVeterinario(Veterinario veterinario)
        {
            var VeterinarioAdicionado = _appContext.Veterinarios.Add(veterinario);
            _appContext.SaveChanges();
            return VeterinarioAdicionado.Entity;
        }

        public void DeleteVeterinario(int idveterinario)
        {
            var VeterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == idveterinario);
            _appContext.Veterinarios.Remove(VeterinarioEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Veterinario> GetAllVeterinarios()
        {
            return _appContext.Veterinarios;
        }

        public Veterinario GetVeterinario(int idveterinario)
        {
            return _appContext.Veterinarios.FirstOrDefault(v => v.Id == idveterinario);
        }

        public Veterinario GetVeterinario(Vaca bovino)
        {
            return _appContext.Veterinarios.FirstOrDefault(vet => vet.BovinosaCargo.FirstOrDefault(v => v.Id == bovino.Id) != null);
        }

        public Veterinario GetVeterinarioPorCedula(int Num_Identificacion)
        {
            return _appContext.Veterinarios.FirstOrDefault(v => v.Num_Identificacion == Num_Identificacion);
        }

        public Veterinario UpdateVeterinario(Veterinario veterinario)
        {
            var VeterinarioEncontrado = _appContext.Veterinarios.FirstOrDefault(v => v.Id == veterinario.Id);
            if (VeterinarioEncontrado != null)
            {
                VeterinarioEncontrado.Nombres = veterinario.Nombres;
                VeterinarioEncontrado.Apellidos = veterinario.Apellidos;
                VeterinarioEncontrado.Direccion = veterinario.Direccion;
                VeterinarioEncontrado.Telefono = veterinario.Telefono;
                VeterinarioEncontrado.TarjetaProfesional = veterinario.TarjetaProfesional;
                VeterinarioEncontrado.BovinosaCargo = veterinario.BovinosaCargo;
                _appContext.SaveChanges();
            }

            return VeterinarioEncontrado;
        }
    }
}