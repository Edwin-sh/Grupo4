using System.Collections.Generic;
using BovinoRemoto.App.Dominio;

namespace BovinoRemoto.App.Persistencia
{
    public interface IRepositorioDueño
    {
        Dueño AddDueño(Dueño dueño);
        void DeleteDueño(int iddueño);
        IEnumerable<Dueño> GetAllDueños();
        Dueño GetDueño(int iddueño);
        Dueño GetDueño(Vaca bovino);
        Dueño GetDueñoPorCedula(int Num_Identificacion);
        Dueño UpdateDueño(Dueño dueño);
    }
}