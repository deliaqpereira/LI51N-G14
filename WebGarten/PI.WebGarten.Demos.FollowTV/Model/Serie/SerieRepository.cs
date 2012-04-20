using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PI.WebGarten.Demos.FollowTV.Episodes.Model;
using PI.WebGarten.Demos.FollowTV.Prog.Model;



namespace PI.WebGarten.Demos.FollowTV.Serie.Model
{
    class SerieRepository
    {
        private readonly IDictionary<ProgItem, EpisodeMemoryRepository> _serie = new Dictionary<ProgItem, EpisodeMemoryRepository>();
        private ProgramMemoryRepository _repoProgram = ProgramLocator.Get();
        
        public IEnumerable<EpisodeMemoryRepository> GetAll()
        {
            return _serie.Values;
        }

        public IEnumerable<ProgItem> GetAllPrograms()
        {
            return _repoProgram.GetAll();
        }

        public IEnumerable<Episode> GetAllEpisodesFrom(string name)
        { 
            ProgItem p = new ProgItem();
            p.Name = name;

            EpisodeMemoryRepository rep = GetByProgram(p);
            return rep.GetAll();
        }


        public EpisodeMemoryRepository GetByProgram(ProgItem p)
        {
            EpisodeMemoryRepository repo = null;
            _serie.TryGetValue(p, out repo);
            return repo;
        }

        public void Add(ProgItem p, Episode e)
        {
            EpisodeMemoryRepository dicEpisodes = GetByProgram(p);

            if (dicEpisodes == null)
            {
                _repoProgram.Add(p);
                dicEpisodes = new EpisodeMemoryRepository();
                dicEpisodes.Add(e);
                _serie.Add(p, dicEpisodes);
            }
            else
            {
                //programa já adicionado

                Episode _episode = dicEpisodes.GetByTitle(e.Title);
                if (_episode == null)
                {
                    dicEpisodes.Add(e);
                }
                else
                {
                    //actualiza campos

                    /*_episode.Acr = fuc.Acr;
                    _fucproposta.Descricao = fuc.Descricao;
                    _fucproposta.Opcional = fuc.Opcional;
                    _fucproposta.Verao = fuc.Verao;
                    _fucproposta.Creditos = fuc.Creditos;
                    */
                }
            }
        }
    }
}
