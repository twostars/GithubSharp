using GithubSharp.Core.Services;

namespace GithubSharp.MvcSample.MvcApplication.Controllers
{
    public sealed class UserController : BaseAPIController<Core.API.UserRepository>
    {
        public UserController(ICacheProvider Cache, ILogProvider Log)
            : base(Cache, Log)
        {
            BaseAPI = new Core.API.UserRepository(Cache, Log);
        }
    }
}
