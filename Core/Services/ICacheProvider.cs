using System;

namespace GithubSharp.Core.Services
{

    //TODO - untested/legacy - is this even what i want?
    public interface ICacheProvider
    {
        T Get<T>(string name) where T : class;
        T Get<T>(string name, int cacheDurationInMinutes) where T : class;
        bool IsCached<T>(string name) where T : class;
        void Set<T>(T objectToCache, string name) where T : class;
        void Delete(string name);
        void DeleteWhereStartingWith(string name);
        void DeleteAll<T>() where T : class;
        int DefaultDuractionInMinutes { get; }
    }

    //TODO - untested/legacy - is this even what i want?
    public class CachedObject<T> where T : class
    {
        public T Cached { get; set; }
        public DateTime When { get; set; }
    }
}
