using System.Collections.Generic;

namespace medDatabase.Populater.Interfaces
{
    public interface ILoader
    {
        IEnumerable<T> LoadFromResource<T>(string resourceName);
    }
}
