using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowTV.Episodes.Model
{
    interface IEpisodeRepository
    {
       IEnumerable<Episode> GetAll();
       Episode GetByTitle(string title);
       void Add(Episode td);
    }
}
