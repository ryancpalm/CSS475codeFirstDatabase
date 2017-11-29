using System.Collections.Generic;

namespace medDatabase.Domain.Interfaces
{
    public interface ILoader
    {
        IEnumerable<T> LoadFromResource<T>(string resourceName);
    }
}
