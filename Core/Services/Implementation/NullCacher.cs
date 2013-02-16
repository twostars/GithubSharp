namespace GithubSharp.Core.Services.Implementation
{
    //TODO - untested/legacy - is this even what i want?
    public class NullCacher : ICacheProvider
	{
		public T Get<T> (string name) where T : class
		{
			return null;
		}

		public T Get<T> (string name, int cacheDurationInMinutes) where T : class
		{
			return null;
		}

		public bool IsCached<T> (string name) where T : class
		{
			return false;
		}

		public void Set<T> (T objectToCache, string name) where T : class
		{
		}

		public void Delete (string name)
		{
		}

		public void DeleteWhereStartingWith (string name)
		{
		}

		public void DeleteAll<T> () where T : class
		{
		}

		public int DefaultDuractionInMinutes {
			get {
				return 1;
			}
		}
	}
}

