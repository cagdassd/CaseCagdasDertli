using WebAPI.Caching;
using WebAPI.Caching.Microsoft;

namespace WebAPI.DependencyResolvers
{
	public class CoreModule
	{
		public void Load(IServiceCollection serviceCollection)
		{
			serviceCollection.AddMemoryCache();
			serviceCollection.AddSingleton<ICacheManager,MemoryCacheManager>();
		}
	}
}
