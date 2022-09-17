using System.Collections.Generic;
using BovinoRemoto.App.Dominio;
using System.Linq;

namespace BovinoRemoto.App.Persistencia
{
    public class RepositorioDueño : IRepositorioDueño
    {
        public readonly AppContext _appContext;

        public RepositorioDueño(AppContext appContext)
        {
            _appContext = appContext;
        }

        public Dueño AddDueño(Dueño dueño)
        {
            var DueñoAdicionado = _appContext.Dueños.Add(dueño);
            _appContext.SaveChanges();
            return DueñoAdicionado.Entity;
        }

        public void DeleteDueño(int iddueño)
        {
            var DueñoEncontrado = _appContext.Dueños.FirstOrDefault(d => d.Id == iddueño);
            _appContext.Dueños.Remove(DueñoEncontrado);
            _appContext.SaveChanges();
        }

        public IEnumerable<Dueño> GetAllDueños()
        {
            return _appContext.Dueños;
        }

        public Dueño GetDueño(int iddueño)
        {
            return _appContext.Dueños.FirstOrDefault(d => d.Id == iddueño);
        }

        public Dueño GetDueñoPorCedula(int Num_Identificacion)
        {
            return _appContext.Dueños.FirstOrDefault(d => d.Num_Identificacion == Num_Identificacion);
        }

        public Dueño UpdateDueño(Dueño dueño)
        {
            var DueñoEncontrado = _appContext.Dueños.FirstOrDefault(d => d.Id == dueño.Id);
            if (DueñoEncontrado != null)
            {
                DueñoEncontrado.Nombres = dueño.Nombres;
                DueñoEncontrado.Apellidos = dueño.Apellidos;
                DueñoEncontrado.Direccion = dueño.Direccion;
                DueñoEncontrado.Telefono = dueño.Telefono;
                DueñoEncontrado.Correo = dueño.Correo;

                _appContext.SaveChanges();
            }

            return DueñoEncontrado;
        }
    }
}