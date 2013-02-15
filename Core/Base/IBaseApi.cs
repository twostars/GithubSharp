namespace GithubSharp.Core.Base
{
    public interface IBaseApi
    {
        void Authenticate(Models.GithubUser user);
    }
}