using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Domain.RepositoryInterface;
using Domain.DomainEntity;

namespace DAL
{
    class SerieMemoryRepository:ISerieRepository
    {
        private readonly IDictionary<ProgItem, IEpisodeRepository> _serie = new Dictionary<ProgItem, IEpisodeRepository>();

        public IEnumerable<IEpisodeRepository> GetAll()
        {
            return _serie.Values;
        }

        public IEnumerable<ProgItem> GetAllPrograms()
        {
            return _serie.Keys;
        }

        public ProgItem GetProgramByName(string name)
        {
            foreach (ProgItem p in _serie.Keys)
            {
                if (p.Name.Equals(name))
                    return p;
            }

            return null;
        }

        public IEnumerable<Episode> GetAllEpisodesFrom(string name)
        {
            ProgItem p = GetProgramByName(name);

            if (p != null)
            {
                IEpisodeRepository repo = null;
                _serie.TryGetValue(p, out repo);

                return repo.GetAll();
            }

            return null;
        }

        


        public IEpisodeRepository GetByProgram(ProgItem p)
        {
            IEpisodeRepository repo = null;
            _serie.TryGetValue(p, out repo);
            return repo;
        }

        public void Add(ProgItem p, Episode e)
        {
            IEpisodeRepository dicEpisodes = GetByProgram(p);

            if (dicEpisodes == null)
            {
              //  _repoProgram.Add(p);
                dicEpisodes = new EpisodeMemoryRepository();
                
                if (e != null)
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
