using BovinoRemoto.App.Dominio;

namespace BovinoRemoto.App.Persistencia
{
    public class RepositorioBovino : IRepositorioBovino
    {
        public readonly AppContext _appContext;

        public RepositorioBovino(AppContext appContext)
        {
            _appContext = appContext;
        }
        public Vaca AddVaca(Vaca bovino)
        {
            var BovinoAdicionado = _appContext.Vacas.Add(bovino);
            _appContext.SaveChanges();
            return BovinoAdicionado.Entity;
        }

        public void DeleteVaca(int idbovino)
        {
            var BovinoEncontrado = _appContext.Dueños.FirstOrDefault(v => v.Id == idbovino);
            _appContext.Dueños.Remove(BovinoEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Vaca> GetAllVacas()
        {
            return _appContext.Vacas;
        }

        public Vaca GetVaca(int idbovino)
        {
            return _appContext.Vacas.FirstOrDefault(v => v.Id == idbovino);
        }

        public IEnumerable<Vaca> GetVacasPorDueño(int iddueño)
        {
            return _appContext.Vacas.Where(v => v.Dueño.Id == iddueño);
        }

        public Vaca UpdateVaca(Vaca bovino)
        {
            var BovinoEncontrado = _appContext.Vacas.FirstOrDefault(v => v.Id == bovino.Id);
            if (BovinoEncontrado != null)
            {
                BovinoEncontrado.Nombre = bovino.Nombre;
                BovinoEncontrado.Especie = bovino.Especie;
                BovinoEncontrado.Raza = bovino.Raza;
                BovinoEncontrado.Dueño = bovino.Dueño;
                BovinoEncontrado.Veterinario = bovino.Veterinario;
                BovinoEncontrado.HistoriaClinica = bovino.HistoriaClinica;
                _appContext.SaveChanges();
            }
            return BovinoEncontrado;
        }
    }
}