using System.Web.Mvc;
using GithubSharp.Core.API;
using GithubSharp.Core.Services;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public sealed class NetworkController : BaseAPIController<NetworksRepository>
    {
        public NetworkController(ICacheProvider CacheProvider, ILogProvider LogProvider)
            : base(CacheProvider, LogProvider)
        {
            BaseAPI = new NetworksRepository(CacheProvider, LogProvider);
        }

        [AcceptVerbs(HttpVerbs.Get)]
        public ActionResult Index()
        {
            var meta = BaseAPI.Meta(CurrentUser.Name, "Swahili");
            return View();
        }
    }
}
