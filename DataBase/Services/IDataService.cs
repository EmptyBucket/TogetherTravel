using System.Linq;

namespace DataBase.Services
{
    public interface IDataService<T>
    {
        IQueryable<T> GetAll();
        string Add(T user);
    }
}