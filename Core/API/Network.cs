using System.Collections.Generic;
using GithubSharp.Core.Models;

namespace GithubSharp.Core.API
{
    public class NetworksRepository : Base.BaseApi
    {
        public NetworkMeta Meta(string username, string repositoryName)
        {
            var url = string.Format("http://github.com/{0}/{1}/network_meta", username, repositoryName);
            return ConsumeJsonUrl<NetworkMeta>(url);
        }

        public IEnumerable<NetworkChunk> MetaChunks(string username, string repositoryName, string networkHash)
        {
            return MetaChunks(username, repositoryName, networkHash, -1, -1);
        }

        public IEnumerable<NetworkChunk> MetaChunks(string username, string repositoryName, string networkHash, int start, int end)
        {
            var url = string.Format("http://github.com/{0}/{1}/network_data_chunk?nethash={2}{3}",
                username,
                repositoryName,
                networkHash,
                end > 0 && start > -1 ?
                    string.Format("?start={0}&end={1}", start, end) : string.Empty);

            var result = ConsumeJsonUrl<Models.Internal.NetworkChunkContainer>(url);

            return result != null ? result.Commits : null;
        }
    }
}
