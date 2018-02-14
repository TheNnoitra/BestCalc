using ItUniverCalcDB.Models;
using System.Collections;
using System.Collections.Generic;

namespace ItUniverCalcDB.Repositories
{
    public interface IEntity
    {
        long Id { get; set; }

    }

    public interface IBaseRepository<T>
        where T : IEntity
    {
        IEnumerable<T> GetAll();

        T Find(long id);

        void Save(T item);

        void Delete(long id);
    }
}