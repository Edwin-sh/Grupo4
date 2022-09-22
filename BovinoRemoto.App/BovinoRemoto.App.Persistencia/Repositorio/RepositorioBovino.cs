using BovinoRemoto.App.Dominio;
using Microsoft.EntityFrameworkCore;

namespace BovinoRemoto.App.Persistencia
{
    public class RepositorioBovino : IRepositorioBovino
    {
        public readonly AppContext _appContext;
        private readonly RepositorioDueño repositorioDueño;

        public RepositorioBovino(AppContext appContext)
        {
            _appContext = appContext;
            this.repositorioDueño = new RepositorioDueño(appContext);
        }
        public Vaca AddVaca(Vaca bovino, int iddueño)
        {
            var dueñoEncontrado = repositorioDueño.GetDueño(iddueño);
            if (dueñoEncontrado != null)
            {
                if (dueñoEncontrado.Bovinos == null)
                {
                    dueñoEncontrado.Bovinos = new List<Vaca>() { bovino };
                }
                else
                {
                    dueñoEncontrado.Bovinos.Add(bovino);
                }
                var dEditado = repositorioDueño.UpdateDueño(dueñoEncontrado);
                if (dEditado != null)
                {
                    return GetVaca(bovino.Id);
                }
                else
                {
                    return null;
                }
            }
            else
            {
                return null;
            }
        }

        public void DeleteVaca(int idbovino)
        {
            var BovinoEncontrado = _appContext.Vacas.FirstOrDefault(v => v.Id == idbovino);
            _appContext.Vacas.Remove(BovinoEncontrado);
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
            var dueño = _appContext.Dueños.Where(d => d.Id == iddueño)
                                     .Include(d => d.Bovinos)
                                     .FirstOrDefault();
            return dueño.Bovinos;
        }

        public Vaca UpdateVaca(Vaca bovino)
        {
            var BovinoEncontrado = _appContext.Vacas.FirstOrDefault(v => v.Id == bovino.Id);
            if (BovinoEncontrado != null)
            {
                BovinoEncontrado.Nombre = bovino.Nombre;
                BovinoEncontrado.Color = bovino.Color;
                BovinoEncontrado.Especie = bovino.Especie;
                BovinoEncontrado.Raza = bovino.Raza;
                BovinoEncontrado.HistoriaClinica = bovino.HistoriaClinica;
                _appContext.SaveChanges();
            }
            return BovinoEncontrado;
        }
    }
}