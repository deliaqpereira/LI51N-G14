using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowTV.Episodes.Model
{
    class EpisodeRepositoryLocator
    {
        private readonly static IEpisodeRepository Repo = new EpisodeMemoryRepository();
        public static IEpisodeRepository Get()
        {
            return Repo;
        }
        
    }
}
