using PaxSys.Pccms.Domain.Models;

namespace PaxSys.Pccms.Domain
{
    public interface IRepository<T> where T : Entity
    {
        T[] Get();
        T Get(int id);
        void Store(T item);
        void Remove(T item);
    }
}