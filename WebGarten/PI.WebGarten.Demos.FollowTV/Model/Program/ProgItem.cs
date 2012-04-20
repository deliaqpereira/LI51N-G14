using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.Demos.FollowTV.Episodes.Model;

namespace PI.WebGarten.Demos.FollowTV.Prog.Model
{
    class ProgItem
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime DtIni { get; set; }
        public DateTime DtFim { get; set; }
        //private readonly IDictionary<string, EpisodeMemoryRepository> _program = new Dictionary<string, EpisodeMemoryRepository>();
       // private List<IEpisode> Episodes = new List<IEpisode>();

        //public List<IEpisode> GetEpisodes()
        //{
         //   return Episodes;
        //}
    }
}
