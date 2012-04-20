using System.Collections.Generic;

namespace PI.WebGarten.Demos.FollowTV.Episodes.Model
{
    class EpisodeMemoryRepository : IEpisodeRepository
    {
        private readonly IDictionary<string, Episode> _repo = new Dictionary<string, Episode>();
        private int _cid = 0;

        public IEnumerable<Episode> GetAll()
        {
            return _repo.Values;
        }

        public Episode GetByTitle(string title)
        {
            Episode e = null;
            _repo.TryGetValue(title, out e);
            return e;
        }

        public void Add(Episode e)
        {
            _repo.Add(e.Title,e);
        }
     
    }
}
