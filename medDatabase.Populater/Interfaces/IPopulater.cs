using System.Collections.Generic;

namespace medDatabase.Populater.Interfaces
{
    public interface IPopulater<out T>
    {
        IEnumerable<T> GetAll();
    }
}
